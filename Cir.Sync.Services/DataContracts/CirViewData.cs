using Cir.Sync.Services.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Cir.Sync.Services.DataContracts
{

    [DataContract]
    public class CirViewData
    {

        public enum ViewType
        {
            Public = 1,
            Private = 2,
            System = 3,
            MigrationError = 4
        }

        [DataMember]
        public List<CirViewDDList> ViewDetailList;
        
        [DataMember]
        public CirViewFields Fields;

        [DataMember]
        public ViewFilter Filter;

        [XmlIgnore]
        [DataMember]
        public ViewQuickFilter QuickFilter = null;

        [DataMember]
        public string QuickFilterId = "";

        [DataMember]
        public ViewSorter Sort;

        [DataMember]
        public int ResultsPerPage = 50;

        [DataMember]
        public string Name = "UNNAMED";

        [XmlIgnore]
        [DataMember]
        public int ViewId = -1;

        [XmlIgnore]
        [DataMember]
        public ViewType Type = ViewType.Public;

        [XmlIgnore]
        [DataMember]
        public bool? InspectionApplicable = false;

        [XmlIgnore]
        [DataMember]
        public bool? GeneralInspectionApplicable = false;

        [XmlIgnore]
        [DataMember]
        public bool? GBXInspectionApplicable = false;

        [XmlIgnore]
        [DataMember]
        public string CreatedBy = string.Empty;

        [XmlIgnore]
        [DataMember]
        public DateTime Created = DateTime.MinValue;

        [XmlIgnore]
        [DataMember]
        public List<FieldItem> FieldMapping = null;

        [XmlIgnore]
        [DataMember]
        public List<ViewQuickFilter> QuickFilterList = null;

        [XmlIgnore]
        [DataMember]
        public int error { get; set; }

        [XmlIgnore]
        [DataMember]
        public string message { get; set; }

        #region ICloneable Members
        public object Clone()
        {
            var clone = this.MemberwiseClone() as CirViewData;
            clone.Filter = this.Filter.Clone() as ViewFilter;
            clone.Sort = this.Sort.Clone() as ViewSorter;
            return clone;
        }

        #endregion

    }
    public class CirViewDDList
    {
        public long ViewId;
        public string Name;
        public string CreatedBy;
        public string Type;
        public bool? InspectionAvailable;
        public bool? GeneralInspectionApplicable;
        public bool? GBXInspectionApplicable;
    }
    public class CirViewFields
    {
        public List<FieldItem> FieldItems;
        //    = new List<ViewFieldItem>();
        //#region ICloneable Members
        //public object Clone()
        //{
        //    var clone = this.MemberwiseClone() as CirViewFields;
        //    clone.FieldItems = new List<ViewFieldItem>();
        //    foreach (var fieldItem in this.FieldItems)
        //    {
        //        clone.FieldItems.Add(fieldItem.Clone() as ViewFieldItem);
        //    }
        //    return clone;
        //}
        //#endregion
    }
    public class ViewFieldItem : ICloneable
    {
        public FieldItem FieldItem;

        #region ICloneable Members
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }

    public class FieldItem
    {

        public string ColumnName
        {
            get;
            set;
        }


        public string TableName
        {
            get;
            set;
        }

        public string ColumnDisplayName
        {
            get;
            set;
        }
    }


    public class ViewFilter : ICloneable
    {
        public enum MatchType
        {
            Equal = 1,
            NotEqual,
            In,
            NotIn,
            Contains
        }

        public List<ViewFilterItem> FilterItems = new List<ViewFilterItem>();
        public bool MatchAll;

        public bool Match(MetadataItem item)
        {
            if (FilterItems.Count == 0)
            {
                return true;
            }
            bool match = false;
            foreach (var filter in FilterItems)
            {
                if (item.FieldValues[filter.FieldItem.ColumnName] != null)
                {
                    if (filter.Match == ViewFilter.MatchType.In ||
                        filter.Match == ViewFilter.MatchType.NotIn)
                    {
                        bool equal = string.Format(",{0},", filter.Value).Contains(string.Format(",{0},", item.FieldValues[filter.FieldItem.ColumnName]));
                        match = (equal == (filter.Match == MatchType.In));
                    }
                    else if (filter.Match == ViewFilter.MatchType.Contains)
                    {
                        match = (item.FieldValues[filter.FieldItem.ColumnName].IndexOf(filter.Value, StringComparison.InvariantCultureIgnoreCase) != -1);
                    }
                    else
                    {
                        bool equal = (item.FieldValues[filter.FieldItem.ColumnName].Equals(filter.Value, StringComparison.InvariantCultureIgnoreCase));
                        match = (equal == (filter.Match == MatchType.Equal));
                    }

                    // break early
                    if (MatchAll && !match)
                    {
                        // match all + no match found
                        break;
                    }
                    if (!MatchAll && match)
                    {
                        // match any + match found
                        break;
                    }
                }
                else
                {
                    match = false;
                }
            }

            return match;
        }

        #region ICloneable Members
        public object Clone()
        {
            var clone = this.MemberwiseClone() as ViewFilter;
            clone.FilterItems = new List<ViewFilterItem>();
            foreach (var filterItem in this.FilterItems)
            {
                clone.FilterItems.Add(filterItem.Clone() as ViewFilterItem);
            }
            return clone;
        }
        #endregion


    }


    public class ViewFilterItem : ICloneable
    {
        public FieldItem FieldItem;
        //public bool Negate;
        // public string ColumnName;
        // public string TableName;
        public string Value;
        public ViewFilter.MatchType Match = ViewFilter.MatchType.Equal;

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }

    public class ViewSorter : ICloneable
    {
        // public string Field;
        public FieldItem FieldItem;
        public bool Ascending;

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }

    public class ViewQuickFilter : ICloneable
    {
        public ViewQuickFilter()
        { }
        public ViewQuickFilter(int id, string name, FieldItem fieldItem, string value)
        {
            Id = id;
            Name = name;
            FieldItem = fieldItem;
            Value = value;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public FieldItem FieldItem { get; set; }
        public string Value { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}