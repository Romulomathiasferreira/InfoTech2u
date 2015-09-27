using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConsultaFinanceYHOOServiceWebAPI.Models;
using System.Xml;
using System.Xml.XPath;
using ConsultaFinanceYHOOServiceWebAPI.DAO;

namespace ConsultaFinanceYHOOServiceWebAPI.Controllers
{
    public class ConsultaFinanceYahooController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            try
            {
                TrataRetorno objRetorno = new TrataRetorno();
                List<Indice> Indices = new List<Indice>();
                string urlInicial = "http://finance.yahoo.com/webservice/v1/symbols/";
                string urlFinal = "/quote?format=xml&view=detail";
                string[] stringSeparators = new string[] { "," };
                string[] result;

                result = id.Split(stringSeparators, StringSplitOptions.None);
                foreach (string s in result)
                {
                    XPathDocument doc = new XPathDocument(urlInicial + s + urlFinal);
                    Indices.Add(objRetorno.TratarRetorno(doc));
                }

                return Request.CreateResponse(HttpStatusCode.OK, Indices); ;
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
