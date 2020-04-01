using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string cirId = "288483";
                byte[] tmpSource;
                byte[] tmpHash;
                //CloudStorageAccount[] storageBaseUrl = storageAccounts.ToArray();
                tmpSource = ASCIIEncoding.ASCII.GetBytes(cirId);
                //Compute hash based on source data.
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                //compute integer values from hash 
                int intVal = Math.Abs(BitConverter.ToInt32(tmpHash, 0));
                int strgPart = intVal % 15;
                //if (strgPart > 0)
                //    return CloudStorageAccount.Parse(ConfigurationManager.AppSettings[storageConnection + strgPart]);
                //else
                //    return CloudStorageAccount.Parse(ConfigurationManager.AppSettings[storageConnection]);
           
        
     }
    }
}
