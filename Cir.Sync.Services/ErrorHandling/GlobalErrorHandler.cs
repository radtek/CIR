using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using System.Web.Hosting;



namespace Cir.Sync.Services
{
    public class GlobalErrorHandler : IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            var newEx = new FaultException(
                string.Format("Exception caught at GlobalErrorHandler{0}Method: {1}{2}Message:{3}",
                             Environment.NewLine, error.TargetSite.Name, Environment.NewLine, error.Message));
         
            MessageFault msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);
        }

        // HandleError. Log an error, then allow the error to be handled as usual.
        // Return true if the error is considered as already handled

        public bool HandleError(Exception error)
        {
            string path = HostingEnvironment.ApplicationPhysicalPath;

            try
            {
                string strfilename = Path.Combine(path, @"Logs\\error.txt");
                StreamWriter writer = new StreamWriter(strfilename, true);
                FileInfo f = new FileInfo(strfilename);
                long b = f.Length;

                if (f.Length < 1048576)
                {
                    writer.WriteLine("Exception:{0}{1}Method: {2}{3}Message:{4}",
                         error.GetType().Name, Environment.NewLine, error.TargetSite.Name,
                         Environment.NewLine, error.Message + Environment.NewLine + error.GetBaseException().Message + Environment.NewLine + error.GetBaseException().StackTrace + Environment.NewLine);
                    writer.Dispose();
                }
                //Else If filesize exceeds more than 1 mb, then rename the existing error log file and log exceptions into new log file.
                else
                {
                    writer.Close();
                    writer.Dispose();
                    string newfnm = Path.Combine(path, @"Logs\\SyncSevErrorLog" + DateTime.Today.ToString("dd-MMM-yyyy-hhmmss") + ".txt");
                    System.IO.File.Move(strfilename, newfnm);
                    StreamWriter newWriter = new StreamWriter(strfilename, true);
                    writer.WriteLine("Exception:{0}{1}Method: {2}{3}Message:{4}",
                        error.GetType().Name, Environment.NewLine, error.TargetSite.Name,
                        Environment.NewLine, error.Message + Environment.NewLine + error.GetBaseException().Message + Environment.NewLine + error.GetBaseException().StackTrace + Environment.NewLine);
                    newWriter.Close();
                    newWriter.Dispose();
                }
            }
            catch (Exception ex1)
            {
                return false;
            }
            return true;
        }

        public void Log(string Message)
        {
            string path = HostingEnvironment.ApplicationPhysicalPath;
            string strfilename = Path.Combine(path, @"Logs\\log.txt");
            StreamWriter writer = new StreamWriter(strfilename, true);
            FileInfo f = new FileInfo(strfilename);
            long b = f.Length;

            if (f.Length < 1048576)
            {
                writer.WriteLine("Exception:{0}{1}Method: {2}{3}Message:{4}",
                     "NA", Environment.NewLine, "Cir Sync Service",
                     Environment.NewLine, Message + Environment.NewLine);
                writer.Dispose();
            }
        }

    }
}