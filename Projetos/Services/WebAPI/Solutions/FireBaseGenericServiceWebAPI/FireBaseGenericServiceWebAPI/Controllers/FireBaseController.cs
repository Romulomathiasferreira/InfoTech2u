using System;
using System.Web.Http;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using FireSharp.Response;


namespace FireBaseGenericServiceWebAPI.Controllers
{
    public class FireBaseController : ApiController
    {
        public HttpResponseMessage Get(string AuthSecret, string BasePath, string command) {
            try
            {
                IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = AuthSecret,
                    BasePath = BasePath
                };

                IFirebaseClient client = new FirebaseClient(config);

                FirebaseResponse response;

                if (String.IsNullOrWhiteSpace(command))
                    response = client.Get("/");
                else
                    response = client.Get("/"+command.ToString());

                return Request.CreateResponse(HttpStatusCode.OK, response); ;
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possível criptografar a entrada: ", command);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }
    }
}
