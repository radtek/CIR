using Cir.BlobStorage.FileHandlerNS;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Repository
{
    public class FileHandlerFactory: IFileHandlerFactory
    {
        public IFileHandler CreateLastModifiedFileHandler(Action<JObject> action)
        {
            return new LastModifiedFileHandler(action);
        }

        public IFileCollector CreateAggregateFileHandler()
        {
            return new AggregateFileHandler();
        }
    }
}
