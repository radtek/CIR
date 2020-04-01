using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLCirAttachments
    {
        public static bool SaveAttachment(CirAttachments attachment)
        {
            DAL.DACirAttachment d = new DAL.DACirAttachment();
            return d.SaveAttachment(attachment);

        }
        public static IEnumerable<CirAttachments> GetAttachments(long cirId)
        {

            DAL.DACirAttachment d = new DAL.DACirAttachment();
            return d.GetAttachments(cirId);
        }
        
        
        public static  bool Delete(long cirAttachmentId)
        {
            DAL.DACirAttachment d = new DAL.DACirAttachment();
            return d.Delete(cirAttachmentId);

        }

        public static CirAttachments Get(long cirAttachmentId)
        {
            DAL.DACirAttachment d = new DAL.DACirAttachment();
            return d.Get(cirAttachmentId);

        }
    }
}