using System;
using System.Threading;
using System.Web.Hosting;

namespace Cir.Data.Access.Helpers
{
    public static class TaskHelper
    {
        public static void StartBackgroundTask(Action<CancellationToken> action)
        {
            HostingEnvironment.QueueBackgroundWorkItem(action);
        }
    }
}
