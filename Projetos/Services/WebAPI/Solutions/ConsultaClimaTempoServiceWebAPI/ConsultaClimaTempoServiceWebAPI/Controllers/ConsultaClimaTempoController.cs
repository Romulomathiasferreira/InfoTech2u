using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConsultaClimaTempoServiceWebAPI.Models;

namespace ConsultaClimaTempoServiceWebAPI.Controllers
{
    public class ConsultaClimaTempoController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {

            try
            {
                DataSet ds = new DataSet();
                Cidade cidade = new Cidade();
                Previsao previsao;
                List<Previsao> listaPrevisao = new List<Previsao>();

                ds.ReadXml("http://servicos.cptec.inpe.br/XML/cidade/244/previsao.xml");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cidade.Nome = ds.Tables[0].Rows[0]["nome"].ToString().Trim();
                        cidade.Uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                        cidade.Atualizacao = ds.Tables[0].Rows[0]["atualizacao"].ToString().Trim();

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                previsao = new Previsao {
                                    Dia = ds.Tables[1].Rows[i]["dia"].ToString().Trim(),
                                    Tempo = ds.Tables[1].Rows[i]["tempo"].ToString().Trim(),
                                    Maxima = ds.Tables[1].Rows[i]["maxima"].ToString().Trim(),
                                    Minima = ds.Tables[1].Rows[i]["minima"].ToString().Trim(),
                                    IUV = ds.Tables[1].Rows[i]["iuv"].ToString().Trim()
                                };
                                listaPrevisao.Add(previsao);
                            }
                        }
                        cidade.listPrevisao = listaPrevisao;
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, cidade); ;
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
