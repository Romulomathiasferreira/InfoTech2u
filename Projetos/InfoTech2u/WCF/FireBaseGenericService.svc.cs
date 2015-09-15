using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.EventStreaming;
using FireSharp.Exceptions;
using FireSharp.Extensions;
using FireSharp.Response;
using FireSharp.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ServiceStack;
using FireSharp.Serialization.JsonNet;
using FireSharp.Serialization.ServiceStack;
using Firebase;

namespace WCF
{
    public class FireBaseGenericService : IFireBaseGenericService
    {
        #region Método Get no FireBase
        public string GetFireBaseData(string AuthSecret, string BasePath, string item)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = AuthSecret,
                BasePath = BasePath
            };

            IFirebaseClient client = new FirebaseClient(config);


            FirebaseResponse response = client.Get(item.ToString());

            //string retorno = JsonConvert.SerializeObject(response).ToString();
            string retorno = response.Body.ToString();

            return retorno;
        }
        #endregion

        #region Método Set no FireBase
        public string SetFireBaseData(string AuthSecret, string BasePath, string item)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = AuthSecret,
                BasePath = BasePath
            };

            IFirebaseClient client = new FirebaseClient(config);

            var todo = new
            {
                name = "Execute SET",
                priority = 2
            };

            SetResponse response = client.Set(item, todo);

            string retorno = JsonConvert.SerializeObject(response).ToString();

            return retorno;
        }
        #endregion

        #region Método Push no FireBase
        public string PushFireBaseData(string AuthSecret, string BasePath, string item)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = AuthSecret,
                BasePath = BasePath
            };

            IFirebaseClient client = new FirebaseClient(config);

            var todo = new
            {
                name = "Execute PUSH",
                priority = 2
            };

            PushResponse response = client.Push(item, todo);

            string retorno = JsonConvert.SerializeObject(response).ToString();

            return retorno;
        }
        #endregion

        #region Método Update no FireBase
        public string UpdateFireBaseData(string AuthSecret, string BasePath, string item)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = AuthSecret,
                BasePath = BasePath
            };

            IFirebaseClient client = new FirebaseClient(config);

            var todo = new
            {
                name = "Execute UPDATE",
                priority = 1
            };

            FirebaseResponse response = client.Update(item, todo);

            string retorno = JsonConvert.SerializeObject(response).ToString();

            return retorno;
        }
        #endregion

        #region Método Delete no FireBase
        public string DeleteFireBaseData(string AuthSecret, string BasePath, string item)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = AuthSecret,
                BasePath = BasePath
            };

            IFirebaseClient client = new FirebaseClient(config);

            FirebaseResponse response = client.Delete(item);

            string retorno = JsonConvert.SerializeObject(response).ToString();

            return retorno;
        }
        #endregion

        #region Método Firebase Token Generator
        public string FirebaseTokenGenerator(string chave, string uid, string some, string data)
        {
            var tokenGenerator = new TokenGenerator(chave);
            var authPayload = new Dictionary<string, object>()
                {
                  { "uid", uid },
                  { "some", some },
                  { "data", data }
                };
            string token = tokenGenerator.CreateToken(authPayload);

            return token;
        }
        #endregion
    }
}
