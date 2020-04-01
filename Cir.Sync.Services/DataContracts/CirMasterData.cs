using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Cir.Sync.Services.DataContracts
{

    [DataContract]
    public class PDFModel
    {
        [DataMember]
        public long PDFId { get; set; }
        [DataMember]
        public byte[] PDFData { get; set; }
        [DataMember]
        public int CIRState { get; set; }
        [DataMember]
        public string CIRTemplateGUID { get; set; }
        [DataMember]
        public string CIRName { get; set; }
    }
    /// <summary>
    /// Master data entity
    /// </summary>
    [DataContract]
    public class CirMasterData
    {
        private string _key;
        private List<MasterKeyValue> _masterKeyValue;
        [DataMember]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        [DataMember]
        public List<MasterKeyValue> MasterKeyValue
        {
            get { return _masterKeyValue; }
            set { _masterKeyValue = value; }
        }
    }

    /// <summary>
    /// Master data entity
    /// </summary>
    [DataContract]
    public class CirMasterTable
    {
        private string _key;
        private string _Text;
        private string _Value;

        [DataMember]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        [DataMember]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        [DataMember]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }

    /// <summary>
    /// Dropdown key value
    /// </summary>
    [DataContract]
    public class MasterKeyValue
    {
        private string _keyType;
        private string _key;
        private string _value;

        [DataMember]
        public string keyType
        {
            get { return _keyType; }
            set { _keyType = value; }
        }
        [DataMember]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        [DataMember]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    //CIMCase

    [DataContract]
    public class CirCIMCaseTable
    {
        private int _CaseNo;
        private string _Description;
        private string _lable;

        [DataMember]
        public int value
        {
            get { return _CaseNo; }
            set { _CaseNo = value; }
        }
        [DataMember]
        public string label
        {
            get { return _lable; }
            set { _lable = value; }
        }
        [DataMember]
        public string desc
        {
            get { return _Description; }
            set { _Description = value; }
        }
    }
}