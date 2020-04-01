using Cir.BlobStorage;
using Cir.BlobStorage.FileHandlerNS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    class LastModifiedFileHandler : IFileHandler
    {
        private readonly Action<JObject> action;
        public LastModifiedFileHandler(Action<JObject> action)
        {
            this.action = action;
        }

        public async Task HandleAsync(IReadOnlyCollection<IFile> files)
        {
            try
            {
                // Load text for all files
                var tasks = files.Select(f => f.GetTextAsync());
                await Task.WhenAll(tasks);

                // Find the cir with the latest ModifiedOn date
                var latestModifiedDate = DateTime.MinValue;
                JObject latestModifiedCir = null;
                foreach (var file in files)
                {
                    if( TryParse(file.Text, out var cir) &&
                        (cir.Type == JTokenType.Object) &&
                        (cir["cirSubmissionData"] != null) &&
                        (cir["cirSubmissionData"].Type == JTokenType.Object) &&
                        (cir["cirSubmissionData"]["modifiedOn"] != null) &&
                        (cir["cirSubmissionData"]["modifiedOn"].Type == JTokenType.String) &&
                        DateTime.TryParse(cir["cirSubmissionData"]["modifiedOn"].Value<string>(), out var modifiedOn))
                    {
                        if (modifiedOn > latestModifiedDate)
                        {
                            latestModifiedDate = modifiedOn;
                            latestModifiedCir = cir;
                        }
                    }
                }

                // Invoke callback on the found cir, if any
                if (latestModifiedCir != null)
                {
                    action(latestModifiedCir);
                }
            }
            catch (Exception e)
            {
                throw new FileHandlerException(files, e);
            }
        }

        private bool TryParse(string text, out JObject result)
        {
            try
            {
                using (var reader =
                        new JsonTextReader(new StringReader(text))
                        {
                            DateParseHandling = DateParseHandling.None
                        })
                {
                    result = JObject.Load(reader);
                    return true;
                }
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
