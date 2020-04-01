using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services;
using Cir.Sync.Services.Edmx;
using Cir.Sync.Services.ErrorHandling;
using Cir.Sync.Services.DataContracts;
using System.Data.Objects;
using System.IO;

namespace Cir.Sync.Services.DAL
{
    /// <summary>
    /// Data access for Standard text
    /// </summary>
    public partial class DAFeedback : DANotification
    {
        public static List<DataContracts.FeedbackType> GetFeedbackType()
        {
            List<DataContracts.FeedbackType> lstFeedbackType = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                List<Edmx.FeedbackType> lstEdFeedbackType = (from s in context.FeedbackType select s).ToList();

                if (!ReferenceEquals(lstEdFeedbackType, null))
                {
                    lstFeedbackType = new List<DataContracts.FeedbackType>();
                    foreach (Edmx.FeedbackType oFeedbackType in lstEdFeedbackType)
                    {
                        lstFeedbackType.Add(new DataContracts.FeedbackType() { id = oFeedbackType.FeedbackTypeId, Name = oFeedbackType.Name });
                    }
                }
            }

            return lstFeedbackType;
        }

        /// <summary>
        /// Save and update for Feedback
        /// </summary>
        /// <param name="FeedbackData">Object of standard text</param>
        /// <returns></returns>
        public static DataContracts.Feedback SaveFeedback(DataContracts.Feedback FeedbackData)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.CirFeedback objFeedbackData = (from s in context.CirFeedback
                                                     where s.Id == FeedbackData.Id
                                                          select s).FirstOrDefault();

                if (!ReferenceEquals(objFeedbackData, null)) // Updating existing
                {
                    if (!ReferenceEquals(FeedbackData.Deleted, null) && !FeedbackData.Deleted)
                    {
                        objFeedbackData.Message = FeedbackData.Message;
                        objFeedbackData.FeedbackTypeId = FeedbackData.FeedbackTypeId;
                        objFeedbackData.Modified = DateTime.Now;
                        objFeedbackData.ModifiedBy = FeedbackData.ModifiedBy;
                        objFeedbackData.Enviroment = FeedbackData.Enviroment;
                        objFeedbackData.Deleted = FeedbackData.Deleted;
                    }
                    else
                    {
                        objFeedbackData.Deleted = true;
                    }
                }
                else // Adding new
                {
                    objFeedbackData = new Edmx.CirFeedback();
                    objFeedbackData.Id = FeedbackData.Id;
                    objFeedbackData.Message = FeedbackData.Message;
                    objFeedbackData.FeedbackTypeId = FeedbackData.FeedbackTypeId;
                    objFeedbackData.CreatedBy = FeedbackData.CreatedBy;
                    objFeedbackData.Created = DateTime.Now;
                    objFeedbackData.Deleted = FeedbackData.Deleted;
                    objFeedbackData.Enviroment = FeedbackData.Enviroment;
                    context.CirFeedback.Add(objFeedbackData);
                }

                context.SaveChanges();
                DANotification Sendmail = new DANotification();

                String Body = "User : " + FeedbackData.CreatedBy + System.Environment.NewLine + " Message : " + FeedbackData.Message;

                String Result = Sendmail.SendFeedbackMail("Feedback Mail", Body);

                if (FeedbackData.Id == 0)
                    FeedbackData.Id = objFeedbackData.Id;
            }

            return FeedbackData;
        }


        public static  List<Feedback> GetAllFeedbacks()
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var feedbacklist = from f in context.CirFeedback
                                   where f.Deleted == false
                                   select new Feedback { Id = f.Id, Message = f.Message, FeedbackType = f.FeedbackType.Name, Created = f.Created, CreatedBy = f.CreatedBy, Enviroment = f.Enviroment };
                return feedbacklist.ToList();
            }
        }

        public static bool DeleteFeedback(long id)
        {
            if (id == 999999)
            {
                string DocumentPath = HttpContext.Current.Server.MapPath("CIRTemplates");
                string[] files = Directory.GetFiles(DocumentPath);
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".docx" && File.GetCreationTime(Path.Combine(DocumentPath, Path.GetFileName(file))) < DateTime.Now)
                    {
                        File.Delete(Path.Combine(DocumentPath, Path.GetFileName(file)));
                    }
                }
            }
            else
            {
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    Edmx.CirFeedback objFeedbackData = (from s in context.CirFeedback
                                                        where s.Id == id
                                                        select s).FirstOrDefault();
                    if (objFeedbackData != null)
                    {
                        objFeedbackData.Deleted = true;
                    }
                    context.SaveChanges();
                }
            }
            return true;
        }
    }
}