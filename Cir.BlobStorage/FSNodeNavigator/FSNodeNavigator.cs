using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Cir.BlobStorage.ErrorHandlerNS;
using Cir.BlobStorage.FileHandlerNS;

namespace Cir.BlobStorage
{
    public class FSNodeNavigator: IFSNodeNavigator
    {
        private readonly IEnumerable<IFSNodeLister> listers;
        private readonly IErrorHandler errorHandler;

        public FSNodeNavigator(IEnumerable<IFSNodeLister> listers, IErrorHandler errorHandler)
        {
            this.listers = listers;
            this.errorHandler = errorHandler;
        }


        public async Task RunAsync(string pattern, int groupBy, IFileHandler fileHandler)
        {
            var tasks = listers.Select(async lister => await HandleSingleBlobStorage(lister, pattern, groupBy, fileHandler));
            await Task.WhenAll(tasks);
        }

        private async Task HandleSingleBlobStorage(IFSNodeLister lister, string pattern, int groupBy, IFileHandler fileHandler)
        {
            IContinuationToken continuationToken = null;

            int idx = pattern.IndexOf('*');
            int lastIdx = pattern.LastIndexOf('*');
            string prefix = pattern.Substring(0, idx);

            IFileHandler handler;
            if (groupBy == 0)
            {
                handler = new AggregateFileHandler();
            }
            else
            {
                handler = fileHandler;
            }

            do
            {
                var result = await lister.ListAsync(prefix, continuationToken);
                continuationToken = result.ContinuationToken;


                if (lastIdx == idx)
                {
                    var files = result.Result
                        .OfType<IFile>()
                        .ToArray();
                    var tasks = files.Select(async f =>
                    {
                        try
                        {
                            await handler.HandleAsync(new[] { f });
                        }
                        catch (Exception e)
                        {
                            errorHandler.OnException(e);
                        }
                    });
                    await Task.WhenAll(tasks);
                    //foreach (var file in files)
                    //{
                    //    try
                    //    {
                    //        await handler.HandleAsync(new[] { file });
                    //    }
                    //    catch(Exception e)
                    //    {
                    //        errorHandler.OnException(e);
                    //    }
                    //}
                }
                else
                {
                    var directories = result.Result
                        .OfType<IDirectory>()
                        .ToArray();
                    var tasks = directories.Select(d => HandleSingleBlobStorage(lister, d.FullPath + pattern.Substring(idx + 2), groupBy - 1, handler));
                    await Task.WhenAll(tasks);
                    //foreach (var directory in directories)
                    //{
                    //    string newPattern = directory.FullPath + pattern.Substring(idx + 2);
                    //    await RunAsync(newPattern, groupBy - 1, handler);
                    //}
                }

            } while (continuationToken != null);

            if (groupBy == 0 && ((AggregateFileHandler)handler).Files.Count != 0)
            {
                try
                {
                    await fileHandler.HandleAsync(((AggregateFileHandler)handler).Files.ToList());
                }
                catch (Exception e)
                {
                    errorHandler.OnException(e);
                }
            }
        }


    }
}
