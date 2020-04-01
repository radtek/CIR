using Cir.BlobStorage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Cir.Azure.Functions.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Cir.Repository
{
    public class CirRepository : ICirRepository
    {
        private readonly IFSNodeNavigator navigator;
        private readonly IFileFactory fileFactory;
        private readonly IFileHandlerFactory fileHandlerFactory;

        public CirRepository(
            IFSNodeNavigator navigator,
            IFileFactory fileFactory,
            IFileHandlerFactory fileHandlerFactory)
        {
            this.navigator = navigator;
            this.fileFactory = fileFactory;
            this.fileHandlerFactory = fileHandlerFactory;
        }

        public async Task<IList<JObject>> GetAllAsync(string turbineId, ISpecification spec)
        {
            if (turbineId == null)
                throw new ArgumentNullException("turbineId");

            var cirs = new List<JObject>();
            var handler = fileHandlerFactory.CreateLastModifiedFileHandler(s => cirs.Add(s));
            await navigator.RunAsync($"{turbineId}/CIR/*/RevisionHistory/*", 1, handler);

            if (spec != null)
            {
                return cirs
                    .Where(spec.ToFunc())
                    .ToList();
            }
            return cirs
                .ToList();
        }

        public async Task<IList<JObject>> GetAllAsync(IList<string> turbineIds, ISpecification spec = null)
        {
            if (turbineIds == null)
                throw new ArgumentNullException("turbineIds");

            //var result = new List<JObject>();
            //foreach (var id in turbineIds)
            //{
            //    var partialResult = await GetAllAsync(id, spec);
            //    result.AddRange(partialResult);
            //}
            //return result;
            var tasks = turbineIds.Select(id => GetAllAsync(id, spec));
            var partialResults = await Task.WhenAll(tasks);

            return partialResults
                .SelectMany(r => r)
                .ToList();
        }

        public async Task<JObject> GetExactlyOneAsync(string turbineId, ISpecification spec)
        {
            var all = await GetAllAsync(turbineId, spec);
            if (all.Count > 1)
            {
                throw new Exception($"Database inconsistency. Multiple CIRs found when only one was expected.");
            }
            return all.FirstOrDefault();
        }
        public async Task<bool> StoreFileByCirAsync(string turbineId, string cirId, string filename, string fileContent)
        {
            var file = fileFactory.CreateFile($"{turbineId}/CIR/{cirId}/{filename}");
            try
            {
                await file.WriteTextAsync(fileContent);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetFileByCirAsync(string turbineId, string cirId, string filename)
        {
            var file = fileFactory.CreateFile($"{turbineId}/CIR/{cirId}/{filename}");
            await file.GetTextAsync();
            return file.Text;
        }

    }
}
