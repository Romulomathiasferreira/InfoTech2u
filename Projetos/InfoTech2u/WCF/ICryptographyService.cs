using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    [ServiceContract]
    public interface ICryptographyService
    {
        [OperationContract]
        byte[] RijndaelCryptography(string entrada, byte[] chave, byte[] vetor);

        [OperationContract]
        string RijndaelDescryptography(byte[] entrada, byte[] chave, byte[] vetor);

        [OperationContract]
        byte[] AESCryptography(string entrada, byte[] chave, byte[] vetor);

        [OperationContract]
        string AESDescryptography(byte[] entrada, byte[] chave, byte[] vetor);

        [OperationContract]
        byte[] DESCryptography(string entrada, byte[] chave, byte[] vetor);

        [OperationContract]
        string DESDescryptography(byte[] entrada, byte[] chave, byte[] vetor);

        [OperationContract]
        string EncryptCryptographyService(string entrada);

        [OperationContract]
        string DecryptCryptographyService(string entrada);
    }
}
