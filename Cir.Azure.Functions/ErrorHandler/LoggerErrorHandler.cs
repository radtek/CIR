using Cir.BlobStorage.ErrorHandlerNS;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions
{
    class LoggerErrorHandler : IErrorHandler
    {
        private readonly ILogger logger;
        public LoggerErrorHandler(ILogger logger)
        {
            this.logger = logger;
        }
        public void OnException(Exception e)
        {
            logger.LogError(e, e.Message);
        }
    }
}
