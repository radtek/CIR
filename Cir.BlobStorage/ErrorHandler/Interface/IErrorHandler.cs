using System;

namespace Cir.BlobStorage.ErrorHandlerNS
{
    public interface IErrorHandler
    {
        void OnException(Exception e);
    }
}
