using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.Helpers;
using Cir.Data.Access.Models;
using Cir.Data.Access.Models.Integration;
using Polly;
using Serilog;

namespace Cir.Data.Access.Services.Integration
{
    internal class InspecToolsIntegrationService : IInspecToolsIntegrationService
    {
        private readonly IIntegrationRequestsDataRepository _integrationRequestsDataRepository;
        private readonly ICirSubmissionDataDynamicRepository _cirSubmissionDataDynamicRepository;
        //private readonly ILogger _log;

        public InspecToolsIntegrationService(
            IIntegrationRequestsDataRepository integrationRequestsDataRepository,
            ICirSubmissionDataDynamicRepository cirSubmissionDataDynamicRepository,
            ILogger log)
        {
            _integrationRequestsDataRepository = integrationRequestsDataRepository;
            _cirSubmissionDataDynamicRepository = cirSubmissionDataDynamicRepository;
            //_log = log;
        }

        public void Run()
        {
            var requests = _integrationRequestsDataRepository.GetAllNonFinished();

            //_log.Information("Starting inspect tool integration reqests service with {@requestsCount} requests", requests.Count());

            foreach (var request in requests)
            {
                var cir = _cirSubmissionDataDynamicRepository.GetByCirId(request.CirId,
                    request.CirCollectionName);

                //_log.Information("Starting background task for request {@requestId} status {@requestStatus} for CIR {@cirId}", request.Id, request.RequestState, request.CirId);

                switch (request.OperationType)
                {
                    case OperationType.LockCir:
                    {
                        TaskHelper.StartBackgroundTask(
                            cancellationToken => ExecuteRetryPolicy(token => PostLock(cir, request, token), request,
                                cancellationToken));
                        break;
                    }
                    case OperationType.UnlockCir:
                    {
                        TaskHelper.StartBackgroundTask(
                            cancellationToken => ExecuteRetryPolicy(token => PostUnlock(cir, request, token), request,
                                cancellationToken));
                        break;
                    }
                    case OperationType.PostCir:
                    {
                        TaskHelper.StartBackgroundTask(
                            cancellationToken => ExecuteRetryPolicy(token => PostCirUpdate(cir, request, token), request,
                                cancellationToken));
                        break;
                    }
                    default:
                        continue;
                }
            }
        }

        public void PostCirLock(CirSubmissionData cir, string userName)
        {
            var requestModel = CreateAndAddRequest(cir, userName, OperationType.LockCir);

            //_log.Information("Created integration request for CIR {@cirId} with id {@id} for operation {@operationType}", requestModel.CirId, requestModel.Id, requestModel.OperationType);

            TaskHelper.StartBackgroundTask(
                cancellationToken => ExecuteRetryPolicy(token => PostLock(cir, requestModel, token), requestModel,
                    cancellationToken));
        }

        public void PostCirUnlock(CirSubmissionData cir, string userName)
        {
            var requestModel = CreateAndAddRequest(cir, userName, OperationType.UnlockCir);

            //_log.Information("Created integration request for CIR {@cirId} with id {@id} for operation {@operationType}", requestModel.CirId, requestModel.Id, requestModel.OperationType);

            TaskHelper.StartBackgroundTask(
                cancellationToken => ExecuteRetryPolicy(token => PostUnlock(cir, requestModel, token), requestModel,
                    cancellationToken));
        }

        public void PostCir(CirSubmissionData cir, string userName)
        {
            var requestModel = CreateAndAddRequest(cir, userName, OperationType.PostCir);

            //_log.Information("Created integration request for CIR {@cirId} with id {@id} for operation {@operationType}", requestModel.CirId, requestModel.Id, requestModel.OperationType);

            TaskHelper.StartBackgroundTask(
                cancellationToken => ExecuteRetryPolicy(token => PostCirUpdate(cir, requestModel, token), requestModel,
                    cancellationToken));
        }


        private Task<bool> PostCirUpdate(CirSubmissionData cir, RequestModel request,
            CancellationToken cancellationToken)
        {
            var postCirUrl = string.Format(InspecToolsIntegrationConfig.PostCirSuffix, cir.CirId);

            return PostToInspecTools(postCirUrl, request, cancellationToken,
                () => HttpHelpers.CreateJsonStringContent(cir));
        }

        private Task<bool> PostUnlock(CirSubmissionData cir, RequestModel request, CancellationToken cancellationToken)
        {
            var unlockCirUrl = string.Format(InspecToolsIntegrationConfig.UnlockCirSuffix, cir.CirId, request.RequestedBy);

            return PostToInspecTools(unlockCirUrl, request, cancellationToken);
        }

        private Task<bool> PostLock(CirSubmissionData cir, RequestModel request, CancellationToken cancellationToken)
        {
            var lockCirUrl = string.Format(InspecToolsIntegrationConfig.LockCirSuffix, cir.CirId, request.RequestedBy);

            return PostToInspecTools(lockCirUrl, request, cancellationToken);
        }

        private async Task<bool> PostToInspecTools(string url, RequestModel request,
            CancellationToken cancellationToken,
            Func<HttpContent> contentFunc = null)
        {
            try
            {
                UpdateRequestInProgress(request);

                //_log.Information("Inspec tools request in progress {@requestId}", request.Id);

                var httpClient = await InspecToolsHttpClient.GetInspecToolsHttpClient();
                using (var result = await httpClient.PostAsync(url, contentFunc?.Invoke(), cancellationToken))
                {
                    //_log.Information("Inspec tools integration request {@id} finished, status {@statusCode}", request.Id, result.StatusCode);
                    
                    HandleResponse(result, request);

                    _integrationRequestsDataRepository.Update(request);

                    return result.IsSuccessStatusCode;
                }
            }
            catch (HttpRequestException e)
            {
                //_log.Error(e, "Inspec tools integration request error {@id}", request.Id);
                HandleErrorResponse(request, $"HttpRequestException {e.Message} {e.StackTrace}");

                throw;
            }
            catch (TaskCanceledException e)
            {
                //_log.Error(e, "Inspec tools integration request error {@id}", request.Id);
                HandleErrorResponse(request, $"TaskCanceledException {e.Message} {e.StackTrace}");

                throw;
            }
        }

        private void HandleErrorResponse(RequestModel request, string errorMessage)
        {
            if (request.Errors == null)
            {
                request.Errors = new List<string>();
            }

            request.Errors.Add(errorMessage);

            _integrationRequestsDataRepository.Update(request);
        }

        private async void HandleResponse(HttpResponseMessage response, RequestModel request)
        {
            if (response.IsSuccessStatusCode)
            {
                request.RequestState = RequestState.Done;
            }
            else
            {
                request.RequestState = RequestState.Error;

                if (request.Errors == null)
                {
                    request.Errors = new List<string>();
                }

                var resultContentString = await response.Content.ReadAsStringAsync();

                request.Errors.Add($"Http status code error {response.StatusCode}, content: {resultContentString}");
                //_log.Warning("Inspec tool integration request finished with error {@statusCode} {@content}", response.StatusCode, resultContentString);
            }
        }

        private RequestModel CreateAndAddRequest(CirSubmissionData cir, string userName, OperationType operationType)
        {
            var requestModel = new RequestModel
            {
                CirId = cir.CirId,
                CirCollectionName = cir.CirCollectionName,
                OperationType = operationType,
                RequestState = RequestState.Queued,
                RequestedBy = userName
            };
            var id = _integrationRequestsDataRepository.Add(requestModel);
            requestModel.Id = id;

            return requestModel;
        }

        private void UpdateRequestInProgress(RequestModel request)
        {
            request.RequestState = RequestState.InProgress;
            _integrationRequestsDataRepository.Update(request);
        }

        private async void ExecuteRetryPolicy(Func<CancellationToken, Task<bool>> taskToExecute,
            RequestModel requestModel,
            CancellationToken cancellationToken)
        {
            try
            {
                await Policy
                    .Handle<HttpRequestException>()
                    .Or<TaskCanceledException>()
                    .OrResult<bool>(isSuccessStatusCode => !isSuccessStatusCode)
                    .WaitAndRetryForeverAsync(
                        retryNumber => TimeSpan.FromSeconds(Math.Pow(InspecToolsIntegrationConfig.ReqeustRetrySleepTime,
                            retryNumber)))
                    .ExecuteAsync(async token => await taskToExecute(cancellationToken), cancellationToken);
            }
            catch (Exception e)
            {
                //_log.Error(e, "Inspec tools integration request error {@id}", requestModel.Id);
                HandleErrorResponse(requestModel, $"Unhandled exception {e.Message} {e.StackTrace}");
            }
        }
    }
}
