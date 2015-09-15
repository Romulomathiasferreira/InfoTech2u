﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Born2TrainSiteWebAPI.FireBaseGenericService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FireBaseGenericService.IFireBaseGenericService")]
    public interface IFireBaseGenericService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/GetFireBaseData", ReplyAction="http://tempuri.org/IFireBaseGenericService/GetFireBaseDataResponse")]
        string GetFireBaseData(string AuthSecret, string BasePath, string item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/GetFireBaseData", ReplyAction="http://tempuri.org/IFireBaseGenericService/GetFireBaseDataResponse")]
        System.Threading.Tasks.Task<string> GetFireBaseDataAsync(string AuthSecret, string BasePath, string item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/SetFireBaseData", ReplyAction="http://tempuri.org/IFireBaseGenericService/SetFireBaseDataResponse")]
        string SetFireBaseData(string AuthSecret, string BasePath, string item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/SetFireBaseData", ReplyAction="http://tempuri.org/IFireBaseGenericService/SetFireBaseDataResponse")]
        System.Threading.Tasks.Task<string> SetFireBaseDataAsync(string AuthSecret, string BasePath, string item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/PushFireBaseData", ReplyAction="http://tempuri.org/IFireBaseGenericService/PushFireBaseDataResponse")]
        string PushFireBaseData(string AuthSecret, string BasePath, string item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/PushFireBaseData", ReplyAction="http://tempuri.org/IFireBaseGenericService/PushFireBaseDataResponse")]
        System.Threading.Tasks.Task<string> PushFireBaseDataAsync(string AuthSecret, string BasePath, string item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/UpdateFireBaseData", ReplyAction="http://tempuri.org/IFireBaseGenericService/UpdateFireBaseDataResponse")]
        string UpdateFireBaseData(string AuthSecret, string BasePath, string item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/UpdateFireBaseData", ReplyAction="http://tempuri.org/IFireBaseGenericService/UpdateFireBaseDataResponse")]
        System.Threading.Tasks.Task<string> UpdateFireBaseDataAsync(string AuthSecret, string BasePath, string item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/DeleteFireBaseData", ReplyAction="http://tempuri.org/IFireBaseGenericService/DeleteFireBaseDataResponse")]
        string DeleteFireBaseData(string AuthSecret, string BasePath, string item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/DeleteFireBaseData", ReplyAction="http://tempuri.org/IFireBaseGenericService/DeleteFireBaseDataResponse")]
        System.Threading.Tasks.Task<string> DeleteFireBaseDataAsync(string AuthSecret, string BasePath, string item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/FirebaseTokenGenerator", ReplyAction="http://tempuri.org/IFireBaseGenericService/FirebaseTokenGeneratorResponse")]
        string FirebaseTokenGenerator(string chave, string uid, string some, string data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFireBaseGenericService/FirebaseTokenGenerator", ReplyAction="http://tempuri.org/IFireBaseGenericService/FirebaseTokenGeneratorResponse")]
        System.Threading.Tasks.Task<string> FirebaseTokenGeneratorAsync(string chave, string uid, string some, string data);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFireBaseGenericServiceChannel : Born2TrainSiteWebAPI.FireBaseGenericService.IFireBaseGenericService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FireBaseGenericServiceClient : System.ServiceModel.ClientBase<Born2TrainSiteWebAPI.FireBaseGenericService.IFireBaseGenericService>, Born2TrainSiteWebAPI.FireBaseGenericService.IFireBaseGenericService {
        
        public FireBaseGenericServiceClient() {
        }
        
        public FireBaseGenericServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FireBaseGenericServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FireBaseGenericServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FireBaseGenericServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetFireBaseData(string AuthSecret, string BasePath, string item) {
            return base.Channel.GetFireBaseData(AuthSecret, BasePath, item);
        }
        
        public System.Threading.Tasks.Task<string> GetFireBaseDataAsync(string AuthSecret, string BasePath, string item) {
            return base.Channel.GetFireBaseDataAsync(AuthSecret, BasePath, item);
        }
        
        public string SetFireBaseData(string AuthSecret, string BasePath, string item) {
            return base.Channel.SetFireBaseData(AuthSecret, BasePath, item);
        }
        
        public System.Threading.Tasks.Task<string> SetFireBaseDataAsync(string AuthSecret, string BasePath, string item) {
            return base.Channel.SetFireBaseDataAsync(AuthSecret, BasePath, item);
        }
        
        public string PushFireBaseData(string AuthSecret, string BasePath, string item) {
            return base.Channel.PushFireBaseData(AuthSecret, BasePath, item);
        }
        
        public System.Threading.Tasks.Task<string> PushFireBaseDataAsync(string AuthSecret, string BasePath, string item) {
            return base.Channel.PushFireBaseDataAsync(AuthSecret, BasePath, item);
        }
        
        public string UpdateFireBaseData(string AuthSecret, string BasePath, string item) {
            return base.Channel.UpdateFireBaseData(AuthSecret, BasePath, item);
        }
        
        public System.Threading.Tasks.Task<string> UpdateFireBaseDataAsync(string AuthSecret, string BasePath, string item) {
            return base.Channel.UpdateFireBaseDataAsync(AuthSecret, BasePath, item);
        }
        
        public string DeleteFireBaseData(string AuthSecret, string BasePath, string item) {
            return base.Channel.DeleteFireBaseData(AuthSecret, BasePath, item);
        }
        
        public System.Threading.Tasks.Task<string> DeleteFireBaseDataAsync(string AuthSecret, string BasePath, string item) {
            return base.Channel.DeleteFireBaseDataAsync(AuthSecret, BasePath, item);
        }
        
        public string FirebaseTokenGenerator(string chave, string uid, string some, string data) {
            return base.Channel.FirebaseTokenGenerator(chave, uid, some, data);
        }
        
        public System.Threading.Tasks.Task<string> FirebaseTokenGeneratorAsync(string chave, string uid, string some, string data) {
            return base.Channel.FirebaseTokenGeneratorAsync(chave, uid, some, data);
        }
    }
}
