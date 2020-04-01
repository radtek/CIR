using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.CIR
{
    public class ComponentInspectionReportSkiiP
    {
         public long ComponentInspectionReportSkiiPId
        {
            get;
            set;
        }
         public long ComponentInspectionReportId
        {
            get;
            set;
        }
         public string SkiiPOtherDamagedComponentsReplaced
        {
            get;
            set;
        }
         public long SkiiPCauseId
        {
            get;
            set;
        }
         public long SkiiPQuantityOfFailedModules
        {
            get;
            set;
        }
         public long? SkiiP2MWV521BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP2MWV522BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP2MWV523BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP2MWV524BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP2MWV525BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP2MWV526BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP3MWV521BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP3MWV522BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP3MWV523BooleanAnswerId
         {
             get;
             set;
         }
         public long? SkiiP3MWV524xBooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP3MWV524yBooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP3MWV525xBooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP3MWV525yBooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP3MWV526xBooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP3MWV526yBooleanAnswerId
        {
            get;
            set;
        }         
	     public long? SkiiP850KWV520BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP850KWV524BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP850KWV525BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiP850KWV526BooleanAnswerId
        {
            get;
            set;
        }
         public long? SkiiPClaimRelevantBooleanAnswerId
        {
            get;
            set;
        }
        
         public List<ComponentInspectionReportSkiiPFailedComponent> SkiipFailedComp
         {
             get;
             set;

         }
         public List<ComponentInspectionReportSkiiPNewComponent> SkiipNewComp
         {
             get;
             set;

         }


         public long? SkiiPNumberofComponents { get; set; }
    }
}