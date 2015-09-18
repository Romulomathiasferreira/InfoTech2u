using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GerarSenhaServiceWebAPI.Controllers
{
    public class GerarSenhaController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string senha = "";
            try
            {
                string guid = Guid.NewGuid().ToString().Replace("-", "");
                Random clsRan = new Random();
                Int32 tamanhoSenha = clsRan.Next(16, 16);
                for (Int32 i = 0; i <= tamanhoSenha; i++){senha += guid.Substring(clsRan.Next(1, guid.Length), 1);}
                return Request.CreateResponse(HttpStatusCode.OK, senha); ;
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possível gerar a nova senha");
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }
    }
}
