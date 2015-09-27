using ConsultaBancoCentralWebAPI.br.gov.bcb.www3;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConsultaBancoCentralWebAPI.Models;

namespace ConsultaBancoCentralWebAPI.Controllers
{
    public class CotacaoMoedaController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            try
            {
                var cotacaoService = new FachadaWSSGSService();
                ParametroRetorno retorno = new ParametroRetorno { ValorCotacao = cotacaoService.getUltimoValorVO(Convert.ToInt32(id)).ultimoValor.svalor };

                return Request.CreateResponse(HttpStatusCode.OK, retorno); ;
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possível criptografar a entrada: ", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }
    }
}
