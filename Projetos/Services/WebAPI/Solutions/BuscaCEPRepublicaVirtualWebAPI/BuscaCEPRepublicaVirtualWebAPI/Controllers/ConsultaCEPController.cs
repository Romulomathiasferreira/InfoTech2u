using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuscaCEPRepublicaVirtualWebAPI.Models;
using System.Data;
using System.Text;

namespace BuscaCEPRepublicaVirtualWebAPI.Controllers
{
    public class ConsultaCEPController : ApiController
    {
        public HttpResponseMessage Get(string CEP)
        {
            try
            {
                ParametroRetorno ParametroRetorno = new ParametroRetorno();
                DataSet ds = new DataSet();

                ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + CEP.Replace("-", "").Trim() + "&formato=xml");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ParametroRetorno.Resultado = ds.Tables[0].Rows[0]["resultado"].ToString();
                        switch (ParametroRetorno.Resultado)
                        {
                            case "1":
                                ParametroRetorno.Estado = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                                ParametroRetorno.Cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                                ParametroRetorno.Bairro = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                                ParametroRetorno.TipoLogradouro = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim();
                                ParametroRetorno.Logradouro = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                                ParametroRetorno.ResultadoTexto = "CEP completo";
                                break;
                            case "2":
                                ParametroRetorno.Estado = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                                ParametroRetorno.Cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                                ParametroRetorno.Bairro = "";
                                ParametroRetorno.TipoLogradouro = "";
                                ParametroRetorno.Logradouro = "";
                                ParametroRetorno.ResultadoTexto = "CEP  único";
                                break;
                            default:
                                ParametroRetorno.Estado = "";
                                ParametroRetorno.Cidade = "";
                                ParametroRetorno.Bairro = "";
                                ParametroRetorno.TipoLogradouro = "";
                                ParametroRetorno.Logradouro = "";
                                ParametroRetorno.ResultadoTexto = "CEP não  encontrado";
                                break;
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, ParametroRetorno); ;
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possível criptografar a entrada: ", CEP);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }
    }
}