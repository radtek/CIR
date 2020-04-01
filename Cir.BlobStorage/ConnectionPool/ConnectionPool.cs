using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Cir.BlobStorage
{
    static class ConnectionPool
    {
        public static SemaphoreSlim Semaphore { get; }
        static ConnectionPool()
        {
            Semaphore = new SemaphoreSlim(250); 
        }
    }
}
