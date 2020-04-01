using Cir.BlobStorage;
using Cir.BlobStorage.FileHandlerNS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public class BirRepository : IBirRepository
    {
        private readonly IFSNodeNavigator navigator;
        private readonly IMetadataGetter metadataGetter;
        private readonly IFileHandlerFactory fileHandlerFactory;
        public BirRepository(
            IFSNodeNavigator navigator,
            IMetadataGetter metadataGetter,
            IFileHandlerFactory fileHandlerFactory)
        {
            this.navigator = navigator;
            this.metadataGetter = metadataGetter;
            this.fileHandlerFactory = fileHandlerFactory;
        }

        public async Task<IList<Bir>> GetAsync(
            string turbineId,
            bool? isAnnual,
            IList<int> modifiedYears,
            string birGuid,
            bool metadataOnly = false)
        {
            if (turbineId == null)
                throw new ArgumentNullException("turbineId");
            if (modifiedYears == null)
                throw new ArgumentNullException("modifiedYears");

            var handler = fileHandlerFactory.CreateAggregateFileHandler();

            await navigator.RunAsync(
                $"{turbineId}/BIR/PDF/*",
                -1,
                handler);

            var files = handler.Files;
            await LoadAsync(files, metadataOnly);

            return files
                .Where(f =>
                    isAnnual == null ||
                    (metadataGetter.TryGetBool(f.Metadata, "isAnnual", out var isAnnualResult) &&
                    isAnnualResult == isAnnual.Value))
                .Where(f =>
                    modifiedYears.Count == 0 ||
                    (metadataGetter.TryGetDateTime(f.Metadata, "modified", out var modifiedResult) &&
                    modifiedYears.Contains(modifiedResult.Year)))
                .Where(f =>
                    (birGuid != null)
                    ? f.FullPath.EndsWith($"/{birGuid}.pdf")
                    : f.FullPath.EndsWith($".pdf"))
                .Select(f => MapToBir(f, turbineId))
                .ToList();
        }

        public async Task<IList<Bir>> GetAsync(IList<string> turbineIds, bool? isAnnual, IList<int> modifiedYears, string birGuid, bool metadataOnly = false)
        {
            if (turbineIds == null)
                throw new ArgumentNullException("turbineIds");
            if (modifiedYears == null)
                throw new ArgumentNullException("modifiedYears");

            var tasks = turbineIds.Select(id => GetAsync(id, isAnnual, modifiedYears, birGuid, metadataOnly));
            var partialResults = await Task.WhenAll(tasks);

            return partialResults
                .SelectMany(r => r)
                .ToList();
        }

        private async Task LoadAsync(IList<IFile> files, bool metadataOnly)
        {
            var tasks = new List<Task>();
            tasks.AddRange(
                files.Select(f => f.GetMetadataAsync()));

            if (!metadataOnly)
            {
                tasks.AddRange(
                    files.Select(f => f.GetBytesAsync()));
            }

            await Task.WhenAll(tasks);
        }

        private Bir MapToBir(IFile file, string turbineId)
        {
            var filename = file.FullPath.Substring(file.FullPath.LastIndexOf('/') + 1);
            var hasIsAnnual = metadataGetter.TryGetBool(file.Metadata, "isAnnual", out var isAnnualResult);
            var hasModified = metadataGetter.TryGetDateTime(file.Metadata, "modified", out var modifiedResult);
            var lastModified = file.Properties.LastModified.Value.UtcDateTime;
            var hasRelatedCirs = metadataGetter.TryGetIntList(file.Metadata, "relatedCirs", out var relatedCirs);
            
            var extension = System.IO.Path.GetExtension(filename);
            var birGuid = filename.Substring(0, filename.Length - extension.Length);

            return new Bir
            {
                Filename = filename,
                BirGuid = birGuid,
                IsAnnual = hasIsAnnual ? isAnnualResult : (bool?)null,
                LastModified = hasModified ? modifiedResult : lastModified,
                TurbineId = turbineId,
                RelatedCirs = hasRelatedCirs ? relatedCirs.ToList() : null,
                Content = file.Bytes != null ? Convert.ToBase64String(file.Bytes) : null
            };
        }
    }
}
