﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Born2TrainSiteWebAPI.CryptographyService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CryptographyService.ICryptographyService")]
    public interface ICryptographyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/RijndaelCryptography", ReplyAction="http://tempuri.org/ICryptographyService/RijndaelCryptographyResponse")]
        byte[] RijndaelCryptography(string entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/RijndaelCryptography", ReplyAction="http://tempuri.org/ICryptographyService/RijndaelCryptographyResponse")]
        System.Threading.Tasks.Task<byte[]> RijndaelCryptographyAsync(string entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/RijndaelDescryptography", ReplyAction="http://tempuri.org/ICryptographyService/RijndaelDescryptographyResponse")]
        string RijndaelDescryptography(byte[] entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/RijndaelDescryptography", ReplyAction="http://tempuri.org/ICryptographyService/RijndaelDescryptographyResponse")]
        System.Threading.Tasks.Task<string> RijndaelDescryptographyAsync(byte[] entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/AESCryptography", ReplyAction="http://tempuri.org/ICryptographyService/AESCryptographyResponse")]
        byte[] AESCryptography(string entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/AESCryptography", ReplyAction="http://tempuri.org/ICryptographyService/AESCryptographyResponse")]
        System.Threading.Tasks.Task<byte[]> AESCryptographyAsync(string entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/AESDescryptography", ReplyAction="http://tempuri.org/ICryptographyService/AESDescryptographyResponse")]
        string AESDescryptography(byte[] entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/AESDescryptography", ReplyAction="http://tempuri.org/ICryptographyService/AESDescryptographyResponse")]
        System.Threading.Tasks.Task<string> AESDescryptographyAsync(byte[] entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/DESCryptography", ReplyAction="http://tempuri.org/ICryptographyService/DESCryptographyResponse")]
        byte[] DESCryptography(string entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/DESCryptography", ReplyAction="http://tempuri.org/ICryptographyService/DESCryptographyResponse")]
        System.Threading.Tasks.Task<byte[]> DESCryptographyAsync(string entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/DESDescryptography", ReplyAction="http://tempuri.org/ICryptographyService/DESDescryptographyResponse")]
        string DESDescryptography(byte[] entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/DESDescryptography", ReplyAction="http://tempuri.org/ICryptographyService/DESDescryptographyResponse")]
        System.Threading.Tasks.Task<string> DESDescryptographyAsync(byte[] entrada, byte[] chave, byte[] vetor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/EncryptCryptographyService", ReplyAction="http://tempuri.org/ICryptographyService/EncryptCryptographyServiceResponse")]
        string EncryptCryptographyService(string entrada);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/EncryptCryptographyService", ReplyAction="http://tempuri.org/ICryptographyService/EncryptCryptographyServiceResponse")]
        System.Threading.Tasks.Task<string> EncryptCryptographyServiceAsync(string entrada);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/DecryptCryptographyService", ReplyAction="http://tempuri.org/ICryptographyService/DecryptCryptographyServiceResponse")]
        string DecryptCryptographyService(string entrada);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptographyService/DecryptCryptographyService", ReplyAction="http://tempuri.org/ICryptographyService/DecryptCryptographyServiceResponse")]
        System.Threading.Tasks.Task<string> DecryptCryptographyServiceAsync(string entrada);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICryptographyServiceChannel : Born2TrainSiteWebAPI.CryptographyService.ICryptographyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CryptographyServiceClient : System.ServiceModel.ClientBase<Born2TrainSiteWebAPI.CryptographyService.ICryptographyService>, Born2TrainSiteWebAPI.CryptographyService.ICryptographyService {
        
        public CryptographyServiceClient() {
        }
        
        public CryptographyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CryptographyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CryptographyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CryptographyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public byte[] RijndaelCryptography(string entrada, byte[] chave, byte[] vetor) {
            return base.Channel.RijndaelCryptography(entrada, chave, vetor);
        }
        
        public System.Threading.Tasks.Task<byte[]> RijndaelCryptographyAsync(string entrada, byte[] chave, byte[] vetor) {
            return base.Channel.RijndaelCryptographyAsync(entrada, chave, vetor);
        }
        
        public string RijndaelDescryptography(byte[] entrada, byte[] chave, byte[] vetor) {
            return base.Channel.RijndaelDescryptography(entrada, chave, vetor);
        }
        
        public System.Threading.Tasks.Task<string> RijndaelDescryptographyAsync(byte[] entrada, byte[] chave, byte[] vetor) {
            return base.Channel.RijndaelDescryptographyAsync(entrada, chave, vetor);
        }
        
        public byte[] AESCryptography(string entrada, byte[] chave, byte[] vetor) {
            return base.Channel.AESCryptography(entrada, chave, vetor);
        }
        
        public System.Threading.Tasks.Task<byte[]> AESCryptographyAsync(string entrada, byte[] chave, byte[] vetor) {
            return base.Channel.AESCryptographyAsync(entrada, chave, vetor);
        }
        
        public string AESDescryptography(byte[] entrada, byte[] chave, byte[] vetor) {
            return base.Channel.AESDescryptography(entrada, chave, vetor);
        }
        
        public System.Threading.Tasks.Task<string> AESDescryptographyAsync(byte[] entrada, byte[] chave, byte[] vetor) {
            return base.Channel.AESDescryptographyAsync(entrada, chave, vetor);
        }
        
        public byte[] DESCryptography(string entrada, byte[] chave, byte[] vetor) {
            return base.Channel.DESCryptography(entrada, chave, vetor);
        }
        
        public System.Threading.Tasks.Task<byte[]> DESCryptographyAsync(string entrada, byte[] chave, byte[] vetor) {
            return base.Channel.DESCryptographyAsync(entrada, chave, vetor);
        }
        
        public string DESDescryptography(byte[] entrada, byte[] chave, byte[] vetor) {
            return base.Channel.DESDescryptography(entrada, chave, vetor);
        }
        
        public System.Threading.Tasks.Task<string> DESDescryptographyAsync(byte[] entrada, byte[] chave, byte[] vetor) {
            return base.Channel.DESDescryptographyAsync(entrada, chave, vetor);
        }
        
        public string EncryptCryptographyService(string entrada) {
            return base.Channel.EncryptCryptographyService(entrada);
        }
        
        public System.Threading.Tasks.Task<string> EncryptCryptographyServiceAsync(string entrada) {
            return base.Channel.EncryptCryptographyServiceAsync(entrada);
        }
        
        public string DecryptCryptographyService(string entrada) {
            return base.Channel.DecryptCryptographyService(entrada);
        }
        
        public System.Threading.Tasks.Task<string> DecryptCryptographyServiceAsync(string entrada) {
            return base.Channel.DecryptCryptographyServiceAsync(entrada);
        }
    }
}