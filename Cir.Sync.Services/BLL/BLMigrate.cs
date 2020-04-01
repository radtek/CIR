using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLMigrate
    {
        public static List<FirstNotificationDetails> GetNotifications()
        {
            return DAL.DANotification.GetNotifications();
        }

        public static bool SaveFirstNotificationDataDetailstoCosmosDb(FirstNotificationDetails objFN, string fnDataDocumentId)
        {
           return DAL.DANotification.SaveFirstNotificationDataDetailstoCosmosDb(objFN, fnDataDocumentId);
        }


        public static List<SecondNotificationDetails> GetSecondNotificationList()
        {
            return DAL.DANotification.GetSecondNotificationList();
        }

        public static bool SaveSecondNotificationDataDetailstoCosmosDb(SecondNotificationDetails objSN, string fnDataDocumentId)
        {
          return  DAL.DANotification.SaveSecondNotificationDataDetailstoCosmosDb(objSN, fnDataDocumentId);
        }


        public static List<RejectNotificationDetails> GetRejectNotificationList()
        {
            return DAL.DANotification.GetRejectNotificationList();
        }

        public static bool SaveRejectNotificationDataDetailstoCosmosDb(RejectNotificationDetails objRN, string fnDataDocumentId)
        {
          return  DAL.DANotification.SaveRejectNotificationDataDetailstoCosmosDb(objRN, fnDataDocumentId);
        }


    }
}