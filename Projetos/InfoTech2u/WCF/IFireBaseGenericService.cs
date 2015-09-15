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
    public interface IFireBaseGenericService
    {
        [OperationContract]
        string GetFireBaseData(string AuthSecret, string BasePath, string item);

        [OperationContract]
        string SetFireBaseData(string AuthSecret, string BasePath, string item);

        [OperationContract]
        string PushFireBaseData(string AuthSecret, string BasePath, string item);

        [OperationContract]
        string UpdateFireBaseData(string AuthSecret, string BasePath, string item);

        [OperationContract]
        string DeleteFireBaseData(string AuthSecret, string BasePath, string item);

        [OperationContract]
        string FirebaseTokenGenerator(string chave, string uid, string some, string data);
    }
}
