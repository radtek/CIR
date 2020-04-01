using System;

namespace Cir.BlobStorage.ErrorHandlerNS
{
    public class FileErrorHandler : IErrorHandler
    {
        private readonly string filePath;
        public FileErrorHandler(string filePath)
        {
            this.filePath = filePath;
        }
        public void OnException(Exception e)
        {
            Console.WriteLine("--- EXCEPTION ---");
            Console.WriteLine(e.Message);
            var inner = e.InnerException;
            while (inner != null)
            {
                Console.WriteLine("--- INNER EXCEPTION ---");
                Console.WriteLine(inner.Message);
                inner = inner.InnerException;
            } 
            Console.WriteLine("-----------------");

            System.IO.File.AppendAllText(filePath, "---------------- EXCEPTION ----------------" + Environment.NewLine);
            System.IO.File.AppendAllText(filePath, e.Message + Environment.NewLine);
            System.IO.File.AppendAllText(filePath, e.StackTrace + Environment.NewLine);
            inner = e.InnerException;
            while (inner != null) 
            {
                System.IO.File.AppendAllText(filePath, "---------------- INNER EXCEPTION ----------------" + Environment.NewLine);
                System.IO.File.AppendAllText(filePath, inner.Message + Environment.NewLine);
                System.IO.File.AppendAllText(filePath, inner.StackTrace + Environment.NewLine);
                inner = inner.InnerException;
            } 
            System.IO.File.AppendAllText(filePath, Environment.NewLine + Environment.NewLine);

        }
    }
}
