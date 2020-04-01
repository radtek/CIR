using Cir.BlobStorage.FileHandlerNS;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Repository
{
    public interface IFileHandlerFactory
    {
        IFileHandler CreateLastModifiedFileHandler(Action<JObject> action);
        IFileCollector CreateAggregateFileHandler();
    }
}
