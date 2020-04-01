﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cir.Azure.MobileService.CirSyncService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CirMasterData", Namespace="http://schemas.datacontract.org/2004/07/Cir.Sync.Services.DataContracts")]
    [System.SerializableAttribute()]
    public partial class CirMasterData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Cir.Azure.MobileService.CirSyncService.MasterKeyValue[] MasterKeyValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key {
            get {
                return this.KeyField;
            }
            set {
                if ((object.ReferenceEquals(this.KeyField, value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Cir.Azure.MobileService.CirSyncService.MasterKeyValue[] MasterKeyValue {
            get {
                return this.MasterKeyValueField;
            }
            set {
                if ((object.ReferenceEquals(this.MasterKeyValueField, value) != true)) {
                    this.MasterKeyValueField = value;
                    this.RaisePropertyChanged("MasterKeyValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MasterKeyValue", Namespace="http://schemas.datacontract.org/2004/07/Cir.Sync.Services.DataContracts")]
    [System.SerializableAttribute()]
    public partial class MasterKeyValue : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string keyTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key {
            get {
                return this.KeyField;
            }
            set {
                if ((object.ReferenceEquals(this.KeyField, value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string keyType {
            get {
                return this.keyTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.keyTypeField, value) != true)) {
                    this.keyTypeField = value;
                    this.RaisePropertyChanged("keyType");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CirSyncService.ISyncService")]
    public interface ISyncService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncService/GetMasterData", ReplyAction="http://tempuri.org/ISyncService/GetMasterDataResponse")]
        Cir.Azure.MobileService.CirSyncService.CirMasterData[] GetMasterData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncService/GetMasterData", ReplyAction="http://tempuri.org/ISyncService/GetMasterDataResponse")]
        System.Threading.Tasks.Task<Cir.Azure.MobileService.CirSyncService.CirMasterData[]> GetMasterDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncService/SaveCIRData", ReplyAction="http://tempuri.org/ISyncService/SaveCIRDataResponse")]
        string SaveCIRData(string strJsnCir);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncService/SaveCIRData", ReplyAction="http://tempuri.org/ISyncService/SaveCIRDataResponse")]
        System.Threading.Tasks.Task<string> SaveCIRDataAsync(string strJsnCir);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISyncServiceChannel : Cir.Azure.MobileService.CirSyncService.ISyncService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SyncServiceClient : System.ServiceModel.ClientBase<Cir.Azure.MobileService.CirSyncService.ISyncService>, Cir.Azure.MobileService.CirSyncService.ISyncService {
        
        public SyncServiceClient() {
        }
        
        public SyncServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SyncServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SyncServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SyncServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Cir.Azure.MobileService.CirSyncService.CirMasterData[] GetMasterData() {
            return base.Channel.GetMasterData();
        }
        
        public System.Threading.Tasks.Task<Cir.Azure.MobileService.CirSyncService.CirMasterData[]> GetMasterDataAsync() {
            return base.Channel.GetMasterDataAsync();
        }
        
        public string SaveCIRData(string strJsnCir) {
            return base.Channel.SaveCIRData(strJsnCir);
        }
        
        public System.Threading.Tasks.Task<string> SaveCIRDataAsync(string strJsnCir) {
            return base.Channel.SaveCIRDataAsync(strJsnCir);
        }
    }
}
