using HtmlAgilityPack;
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
using UsersRegistrationWebAPI.Models;



namespace UsersRegistrationWebAPI.Controllers
{
    public class UsersRegistrationController : ApiController
    {
        private string respostaCryptography;
        public HttpResponseMessage Get(string idUser, string emailUser, string passwordUser, string userRegistration, string statusUser)
        {
            try
            {
                
                
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument htmldoc = web.Load("https://www.bibliaonline.com.br/nvi/gn/6");
                htmldoc.OptionFixNestedTags = true;
                var navigator = (HtmlNodeNavigator)htmldoc.CreateNavigator();
                string xpath = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/article[1]/p[1]/span[1]";
                string val = navigator.SelectSingleNode(xpath).Value;
                

               /* HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load("https://www.bibliaonline.com.br/nvi/gn/6");
                int count = 0;
                string data = "";
                var output = doc.DocumentNode.SelectNodes("//div[@id='ChapterView']//span");

                foreach (var item in output)
                {
                    count++;
                    if (count == output.Count)
                    {
                        //data = item.Attributes["href"].Value;
                        data = data + item.InnerText[count].ToString();
                    }
                }*/

                User user = new User();
                DateTime now = DateTime.Now;
                
                #region Atribuir/valorizar modelo
                if (!String.IsNullOrWhiteSpace(idUser))
                    user.idUser = Convert.ToInt32(idUser);

                if (!String.IsNullOrWhiteSpace(emailUser))
                    user.emailUser = emailUser;

                if (!String.IsNullOrWhiteSpace(passwordUser))
                {
                    //var request = WebRequest.Create("http://localhost:53164/api/Encrypt/senhaTeste");
                    var request = WebRequest.Create("https://www.bibliaonline.com.br/acf/rm/2/2");
                    string passwordUserEncrypt;
                    var response = (HttpWebResponse)request.GetResponse();

                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        passwordUserEncrypt = sr.ReadToEnd();
                    }

                    JToken token = JObject.Parse(passwordUserEncrypt);
                    user.passwordUser = (string)token.SelectToken("Retorno");
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
                    user.idUser = Convert.ToInt32(idUser);

                if (!String.IsNullOrWhiteSpace(emailUser))
                    user.emailUser = emailUser;

                if (!String.IsNullOrWhiteSpace(passwordUser))
                    user.passwordUser = passwordUser;

                user.registrationDateUser = now;

                if (!string.IsNullOrWhiteSpace(userRegistration))
                    user.registrationUserUser = Convert.ToInt32(userRegistration);

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

        public HttpResponseMessage Put(string idUser, string emailUser, string passwordUser, string userRegistration, string statusUser)
        {
            try
            {
                User user = new User();
                DateTime now = DateTime.Now;
                #region Atribuir/valorizar modelo
                if (!String.IsNullOrWhiteSpace(idUser))
                    user.idUser = Convert.ToInt32(idUser);

                if (!String.IsNullOrWhiteSpace(emailUser))
                    user.emailUser = emailUser;

                if (!String.IsNullOrWhiteSpace(passwordUser))
                    user.passwordUser = passwordUser;

                user.registrationDateUser = now;

                if (!String.IsNullOrWhiteSpace(userRegistration))
                    user.changeUserUser = Convert.ToInt32(userRegistration);
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
                    user.idUser = Convert.ToInt32(idUser);

                user.registrationDateUser = now;

                if (!String.IsNullOrWhiteSpace(userRegistration))
                    user.changeUserUser = Convert.ToInt32(userRegistration);
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
