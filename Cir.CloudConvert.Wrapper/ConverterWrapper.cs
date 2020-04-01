using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cir.CloudConvert.Wrapper.Exceptions;
using Cir.CloudConvert.Wrapper.Extensions;
using Cir.CloudConvert.Wrapper.Interfaces;
using Cir.CloudConvert.Wrapper.Options;
using Cir.CloudConvert.Wrapper.Requests;
using Cir.CloudConvert.Wrapper.Responses;
using AutoMapper;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Cir.CloudConvert.Wrapper
{
    /// <summary>
    /// This represents the converter wrapper entity.
    /// </summary>
    public class ConverterWrapper : IConverterWrapper
    {
        private IFormats _formats;
        private IConverterWrapper _wrapper;
        private InputParameters _input;
        private OutputParameters _output;
        private ConversionParameters _conversion;
        private readonly IConverterSettings _settings;

        private bool _disposed;

        /// <summary>
        /// Initialises a new instance of the <c>ConverterWrapper</c> class.
        public ConverterWrapper()
        {
            _settings = ConverterSettings.CreateInstance();
        }

        /// </summary>
        /// <param name="settings"></param>
        public ConverterWrapper(IConverterSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            this._settings = settings;

            this.InitialiseMapper();
        }

        /// <summary>
        /// Initialises the mapper definitions.
        /// </summary>
        private void InitialiseMapper()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
        }

        public async Task<ConvertResponse> CreatePDFAsync(string filepath, string fileName)
        {
            _formats = new DataFormats.Formats();
            _wrapper = new ConverterWrapper(_settings);
           var _formatDoc = _formats.Document;

            _input = new InputParameters()
            {
                InputFormat = Convert.ToString(_formatDoc.GetType().GetProperties().Single(x => x.Name.ToLower() == fileName.ToLower().Split('.').Last()).GetValue(_formatDoc, null)),
                //InputFormat = _formats.Document.Docx,
                InputMethod = InputMethod.Download,
                Filepath = filepath,
                Filename = fileName,
            };
            _output = new OutputParameters()
            {
                DownloadMethod = DownloadMethod.True,
                OutputStorage = OutputStorage.None
            };
            _conversion = new ConversionParameters()
            {
                OutputFormat = _formats.Document.Pdf,
                ConverterOptions = new MarkdownConverterOptions()
                {
                    InputMarkdownSyntax = MarkdownSyntaxType.Auto
                },
            };

            return await ConvertAsync(_input, _output, _conversion).ConfigureAwait(false);
        }

        /// <summary>
        /// Converts the requested file to a designated format.
        /// </summary>
        /// <param name="input"><c>InputParameters</c> object.</param>
        /// <param name="output"><c>OutputParameters</c> object.</param>
        /// <param name="conversion"><c>ConversionParameters</c> object.</param>
        /// <returns>Returns the conversion response.</returns>
        public async Task<ConvertResponse> ConvertAsync(InputParameters input, OutputParameters output, ConversionParameters conversion)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (output == null)
            {
                throw new ArgumentNullException("output");
            }

            if (conversion == null)
            {
                throw new ArgumentNullException("conversion");
            }

            var processResponse = await this.GetProcessResponseAsync(input.InputFormat, conversion.OutputFormat).ConfigureAwait(false);
            var convertRequest = this.GetConvertRequest(input, output, conversion);
            var convertResponse = await this.ConvertAsync(convertRequest, String.Format("https:{0}", processResponse.Url)).ConfigureAwait(false);
            return convertResponse;
        }

        /// <summary>
        /// Gets the <c>ProcessResponse</c> to be consumed in subsequent requests.
        /// </summary>
        /// <param name="inputFormat">Input file format.</param>
        /// <param name="outputFormat">Output file format.</param>
        /// <returns>Returns the <c>ProcessResponse</c> object to be consumed in subsequent requests.</returns>
        public async Task<ProcessResponse> GetProcessResponseAsync(string inputFormat, string outputFormat)
        {
            if (String.IsNullOrWhiteSpace(inputFormat))
            {
                throw new ArgumentNullException("inputFormat");
            }

            if (String.IsNullOrWhiteSpace(outputFormat))
            {
                throw new ArgumentNullException("outputFormat");
            }

            var request = this.GetProcessRequest(inputFormat, outputFormat);

            ProcessResponse deserialised;
            using (var client = new HttpClient())
            {
                var apiKey = this._settings.Basic.ApiKey.Value;
                var processUrl = this._settings.Basic.ProcessUrl;

                if (this._settings.Basic.UseHeader)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                }
                else
                {
                    request.ApiKey = apiKey;
                }

                var serialised = this.Serialise(request);
                using (var content = new StringContent(serialised, Encoding.UTF8, "application/json"))
                using (var response = await client.PostAsync(processUrl, content).ConfigureAwait(false))
                {
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var error = this.Deserialise<ErrorResponse>(result);
                        throw new ErrorResponseException(error);
                    }
                    deserialised = this.Deserialise<ProcessResponse>(result);
                }
            }

            return deserialised;
        }

        /// <summary>
        /// Gets the <c>ProcessRequest</c> object.
        /// </summary>
        /// <param name="inputFormat">Input file format.</param>
        /// <param name="outputFormat">Output file format.</param>
        /// <returns>Returns the <c>ProcessRequest</c> object.</returns>
        private ProcessRequest GetProcessRequest(string inputFormat, string outputFormat)
        {
            if (String.IsNullOrWhiteSpace(inputFormat))
            {
                throw new ArgumentNullException("inputFormat");
            }

            if (String.IsNullOrWhiteSpace(outputFormat))
            {
                throw new ArgumentNullException("outputFormat");
            }

            var request = new ProcessRequest()
                          {
                              InputFormat = inputFormat,
                              OutputFormat = outputFormat
                          };
            return request;
        }

        /// <summary>
        /// Gets the <c>ConvertRequest</c> object.
        /// </summary>
        /// <param name="input"><c>InputParameters</c> object.</param>
        /// <param name="output"><c>OutputParameters</c> object.</param>
        /// <param name="conversion"><c>ConversionParameters</c> object.</param>
        /// <returns>Returns the <c>ConvertRequest</c> object.</returns>
        public ConvertRequest GetConvertRequest(InputParameters input, OutputParameters output, ConversionParameters conversion)
        {
            var request = Mapper.Map<ConvertRequest>(input)
                                .Map(output)
                                .Map(conversion);
            return request;
        }

        /// <summary>
        /// Converts the requested file to a designated format.
        /// </summary>
        /// <param name="request"><c>ConvertRequest</c> object.</param>
        /// <param name="convertUrl">Process URL to convert.</param>
        /// <returns></returns>
        public async Task<ConvertResponse> ConvertAsync(ConvertRequest request, string convertUrl)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (String.IsNullOrWhiteSpace(convertUrl))
            {
                throw new ArgumentNullException("convertUrl");
            }

            var serialised = this.Serialise(request);
            ConvertResponse retValue = new ConvertResponse();

            using (var client = new HttpClient())
            using (var content = new StringContent(serialised, Encoding.UTF8, "application/json"))
            using (var response = await client.PostAsync(convertUrl, content).ConfigureAwait(false))
            {
                var result = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                retValue.Code = (int)response.StatusCode;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    retValue.Error = response.ToString();;
                }

                using (var memoryStream = new MemoryStream())
                {
                    result.CopyTo(memoryStream);
                    retValue.ResponseString = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return retValue;
        }

        /// <summary>
        /// Serialises the request object in JSON format.
        /// </summary>
        /// <typeparam name="TRequest">Request object type.</typeparam>
        /// <param name="request">Request object.</param>
        /// <returns>Returns the JSON-serialised string.</returns>
        public string Serialise<TRequest>(TRequest request) where TRequest : BaseRequest
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var settings = new JsonSerializerSettings()
                           {
                               ContractResolver = new LowercaseContractResolver()
                           };
            var serialised = JsonConvert.SerializeObject(request, Formatting.None, settings);
            return serialised;
        }

        /// <summary>
        /// Deserialises the JSON serialised string into a designated type.
        /// </summary>
        /// <typeparam name="TResponse">Response object type.</typeparam>
        /// <param name="value">JSON serialised string.</param>
        /// <returns>Returns a deserialised object.</returns>
        public TResponse Deserialise<TResponse>(string value) where TResponse : BaseResponse
        {
            var deserialised = JsonConvert.DeserializeObject<TResponse>(value);
            return deserialised;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<InputParameters, ConvertRequest>()
                  .ForMember(d => d.InputMethod, o => o.MapFrom(s => s.InputMethod.ToLower()));
            CreateMap<OutputParameters, ConvertRequest>()
                  .ForMember(d => d.Email, o => o.MapFrom(s => s.Email ? s.Email : (bool?)null))
                  .ForMember(d => d.OutputStorage, o => o.MapFrom(s => s.OutputStorage != OutputStorage.None ? s.OutputStorage.ToLower() : null))
                  .ForMember(d => d.Wait, o => o.MapFrom(s => s.Wait ? s.Wait : (bool?)null))
                  .ForMember(d => d.DownloadMethod, o => o.MapFrom(s => s.DownloadMethod.ToLower()))
                  .ForMember(d => d.SaveToServer, o => o.MapFrom(s => s.SaveToServer ? s.SaveToServer : (bool?)null));
            CreateMap<ConversionParameters, ConvertRequest>()
                  .ForMember(d => d.Timeout, o => o.MapFrom(s => s.Timeout > 0 ? s.Timeout : (int?)null));
        }
    }
}