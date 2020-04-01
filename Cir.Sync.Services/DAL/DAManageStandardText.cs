using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services;
using Cir.Sync.Services.Edmx;

using Cir.Sync.Services.ErrorHandling;
using Cir.Sync.Services.DataContracts;
using System.Data.Objects;


namespace Cir.Sync.Services.DAL
{
    /// <summary>
    /// Data access for Standard text
    /// </summary>
    public static class DAManageStandardText
    {
        public static List<DataContracts.ComponentInspectionReportType> GetComponentInspectionReportType()
        {
            List<DataContracts.ComponentInspectionReportType> lstComponentInspectionReportType = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                List<Edmx.ComponentInspectionReportType> lstEdComponentInspectionReportType = (from s in context.ComponentInspectionReportType
                                                                                               select s).ToList();

                if (!ReferenceEquals(lstEdComponentInspectionReportType, null))
                {
                    lstComponentInspectionReportType = new List<DataContracts.ComponentInspectionReportType>();
                    foreach (Edmx.ComponentInspectionReportType oComponentInspectionReportType in lstEdComponentInspectionReportType)
                    {
                        lstComponentInspectionReportType.Add(new DataContracts.ComponentInspectionReportType() { id = oComponentInspectionReportType.ComponentInspectionReportTypeId, Name = oComponentInspectionReportType.Name });
                    }
                }
            }

            return lstComponentInspectionReportType;
        }

        public static List<DataContracts.StandardTexts> GetStandardText(Int32 CommonInspectionReportID)
        {
            //List<StandardTexts> lstStandardTexts = new List<StandardTexts>();

            CIM_CIREntities context = new CIM_CIREntities();
            var StandardTextsCol = context.spGetStandardTexts(CommonInspectionReportID);
            var StandardTextsItems = from e in StandardTextsCol
                                     select new StandardTexts
                                     {
                                         Id = e.Id,
                                         Title = e.Title,
                                         Description = e.Description

                                     };
            List<StandardTexts> lstStandardTexts = new List<StandardTexts>(StandardTextsItems.ToList());
            return lstStandardTexts;

        }

        public static DataContracts.StandardTexts GetStandardTextbyID(Int64 SID)
        {
            StandardTexts lstStandardTexts = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                List<Edmx.CirStandardTexts> lstEdStandardTexts = (from s in context.CirStandardTexts
                                                                  where s.Id == SID
                                                                  select s).ToList();

                if (!ReferenceEquals(lstEdStandardTexts, null))
                {
                    foreach (Edmx.CirStandardTexts oStandardTexts in lstEdStandardTexts)
                    {
                        lstStandardTexts = new DataContracts.StandardTexts() { Id = oStandardTexts.Id, Title = oStandardTexts.Title, Description = oStandardTexts.Description, ComponentInspectionReportTypeId = oStandardTexts.ComponentInspectionReportTypeId };
                    }
                }
            }

            return lstStandardTexts;

        }

        /// <summary>
        /// Save and update for standard text
        /// </summary>
        /// <param name="StandardText">Object of standard text</param>
        /// <returns></returns>
        public static DataContracts.StandardTexts SaveStandardTextData(DataContracts.StandardTexts StandardText)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.CirStandardTexts objStandardTexts = (from s in context.CirStandardTexts
                                                          where s.Id == StandardText.Id
                                                          select s).FirstOrDefault();

                if (!ReferenceEquals(objStandardTexts, null)) // Updating existing
                {
                    if (!ReferenceEquals(StandardText.Deleted, null) && !StandardText.Deleted)
                    {
                        objStandardTexts.Title = StandardText.Title;
                        objStandardTexts.Description = StandardText.Description;
                        objStandardTexts.Modified = DateTime.Now;
                        objStandardTexts.ModifiedBy = StandardText.ModifiedBy;
                        objStandardTexts.Deleted = StandardText.Deleted;
                        objStandardTexts.ComponentInspectionReportTypeId = StandardText.ComponentInspectionReportTypeId;
                    }
                    else
                    {
                        objStandardTexts.Deleted = true;
                    }
                }
                else // Adding new
                {
                    objStandardTexts = new Edmx.CirStandardTexts();
                    objStandardTexts.Id = StandardText.Id;
                    objStandardTexts.Title = StandardText.Title;
                    objStandardTexts.Description = StandardText.Description;
                    objStandardTexts.CreatedBy = StandardText.CreatedBy;
                    objStandardTexts.Created = DateTime.Now;
                    objStandardTexts.Deleted = StandardText.Deleted;
                    objStandardTexts.ComponentInspectionReportTypeId = StandardText.ComponentInspectionReportTypeId;
                    context.CirStandardTexts.Add(objStandardTexts);
                }

                context.SaveChanges();

                if (StandardText.Id == 0)
                    StandardText.Id = objStandardTexts.Id;
            }

            return StandardText;
        }

    }
}