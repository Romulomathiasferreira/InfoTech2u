using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using UsersRegistrationWebAPI.dao;
using UsersRegistrationWebAPI.Entidades;

namespace UsersRegistrationWebAPI.Controllers
{
    public class UsersRegistrationController : ApiController
    {
        private UserDAO userDAO;
          
        public UsersRegistrationController (UserDAO userDAO) {
            this.userDAO = userDAO;
        }
        public HttpResponseMessage Get(string idUser, string emailUser, string passwordUser, string userRegistration, string statusUser)
        {
            try
            {
                User user = new User();
                DateTime now = DateTime.Now;
                
                #region Atribuir/valorizar modelo
                if (!String.IsNullOrWhiteSpace(idUser))
                    user.IdUser = Convert.ToInt32(idUser);

                if (!String.IsNullOrWhiteSpace(emailUser))
                    user.EmailUser = emailUser;

                if (!String.IsNullOrWhiteSpace(passwordUser))
                {
                    var request = WebRequest.Create("http://localhost:53164/api/Encrypt/senhaTeste");
                    
                    string passwordUserEncrypt;
                    var response = (HttpWebResponse)request.GetResponse();

                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        passwordUserEncrypt = sr.ReadToEnd();
                    }

                    JToken token = JObject.Parse(passwordUserEncrypt);
                    user.PasswordUser = (string)token.SelectToken("Retorno");
                }
                #endregion

                return Request.CreateResponse(HttpStatusCode.OK, user); ;
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possível criptografar a entrada: ", emailUser);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }
        
        public HttpResponseMessage Post(string idUser, string emailUser, string passwordUser, string userRegistration, string statusUser)
        {
            try
            {
                User user = new User();
                DateTime now = DateTime.Now;
                
                #region Atribuir/valorizar modelo
                if (!String.IsNullOrWhiteSpace(idUser))
                    user.IdUser = Convert.ToInt32(idUser);

                if (!String.IsNullOrWhiteSpace(emailUser))
                    user.EmailUser = emailUser;

                if (!String.IsNullOrWhiteSpace(passwordUser))
                    user.PasswordUser = passwordUser;

                user.RegistrationDateUser = now;

                if (!string.IsNullOrWhiteSpace(userRegistration))
                    user.RegistrationUserUser = Convert.ToInt32(userRegistration);

                #endregion

                userDAO.Adiciona(user);


                return Request.CreateResponse(HttpStatusCode.OK, user); ;
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possível criptografar a entrada: ", emailUser);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        public HttpResponseMessage Put(string idUser, string emailUser, string passwordUser, string userRegistration, string statusUser)
        {
            try
            {
                User user = new User();
                DateTime now = DateTime.Now;
                #region Atribuir/valorizar modelo
                if (!String.IsNullOrWhiteSpace(idUser))
                    user.IdUser = Convert.ToInt32(idUser);

                if (!String.IsNullOrWhiteSpace(emailUser))
                    user.EmailUser = emailUser;

                if (!String.IsNullOrWhiteSpace(passwordUser))
                    user.PasswordUser = passwordUser;

                user.RegistrationDateUser = now;

                if (!String.IsNullOrWhiteSpace(userRegistration))
                    user.ChangeUserUser = Convert.ToInt32(userRegistration);
                #endregion



                return Request.CreateResponse(HttpStatusCode.OK, user); ;
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possível criptografar a entrada: ", emailUser);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        public HttpResponseMessage Delete(string idUser, string emailUser, string passwordUser, string userRegistration, string statusUser)
        {
            try
            {
                User user = new User();
                DateTime now = DateTime.Now;
                #region Atribuir/valorizar modelo
                if (!String.IsNullOrWhiteSpace(idUser))
                    user.IdUser = Convert.ToInt32(idUser);

                user.RegistrationDateUser = now;

                if (!String.IsNullOrWhiteSpace(userRegistration))
                    user.ChangeUserUser = Convert.ToInt32(userRegistration);
                #endregion


                return Request.CreateResponse(HttpStatusCode.OK, user); ;
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possível criptografar a entrada: ", emailUser);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

    }


}
