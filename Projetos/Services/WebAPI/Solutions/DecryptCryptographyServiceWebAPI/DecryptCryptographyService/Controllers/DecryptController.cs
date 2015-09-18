using System;
using System.Web.Http;
using DecryptCryptographyService.Models;
using DecryptCryptographyService.DAO;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;

namespace DecryptCryptographyService.Controllers
{
    public class DecryptController : ApiController
    {
        public HttpResponseMessage Get(string Entrada)
        {
            try
            {
                #region Get Keys and Vectors in Firebase
                FireBaseEntrada EntradaFireBaseChaveAES = new FireBaseEntrada { AuthSecret = "iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", BasePath = "https://cryptography.firebaseio.com/", item = "AES/KEY" };
                FireBaseRetorno RetornoFireBaseChaveAES = new FireBaseRetorno();
                RetornoFireBaseChaveAES = FireBase.GetFireBaseData(EntradaFireBaseChaveAES);
                string chaveAes = RetornoFireBaseChaveAES.Body.Replace("\"", "");

                FireBaseEntrada EntradaFireBaseVetorAES = new FireBaseEntrada { AuthSecret = "iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", BasePath = "https://cryptography.firebaseio.com/", item = "AES/VECTOR" };
                FireBaseRetorno RetornoFireBaseVetorAES = new FireBaseRetorno();
                RetornoFireBaseVetorAES = FireBase.GetFireBaseData(EntradaFireBaseVetorAES);
                string vetorAes = RetornoFireBaseVetorAES.Body.Replace("\"", "");

                FireBaseEntrada EntradaFireBaseChaveDES = new FireBaseEntrada { AuthSecret = "iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", BasePath = "https://cryptography.firebaseio.com/", item = "DES/KEY" };
                FireBaseRetorno RetornoFireBaseChaveDES = new FireBaseRetorno();
                RetornoFireBaseChaveDES = FireBase.GetFireBaseData(EntradaFireBaseChaveDES);
                string chaveDES = RetornoFireBaseChaveDES.Body.Replace("\"", "");

                FireBaseEntrada EntradaFireBaseVetorDES = new FireBaseEntrada { AuthSecret = "iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", BasePath = "https://cryptography.firebaseio.com/", item = "DES/VECTOR" };
                FireBaseRetorno RetornoFireBaseVetorDES = new FireBaseRetorno();
                RetornoFireBaseVetorDES = FireBase.GetFireBaseData(EntradaFireBaseVetorDES);
                string vetorDES = RetornoFireBaseVetorDES.Body.Replace("\"", "");

                FireBaseEntrada EntradaFireBaseChaveRijndael = new FireBaseEntrada { AuthSecret = "iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", BasePath = "https://cryptography.firebaseio.com/", item = "RIJNDAEL/KEY" };
                FireBaseRetorno RetornoFireBaseChaveRijndael = new FireBaseRetorno();
                RetornoFireBaseChaveRijndael = FireBase.GetFireBaseData(EntradaFireBaseChaveRijndael);
                string chaveRijndael = RetornoFireBaseChaveRijndael.Body.Replace("\"", "");

                FireBaseEntrada EntradaFireBaseVetorRijndael = new FireBaseEntrada { AuthSecret = "iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", BasePath = "https://cryptography.firebaseio.com/", item = "RIJNDAEL/VECTOR" };
                FireBaseRetorno RetornoFireBaseVetorRijndael = new FireBaseRetorno();
                RetornoFireBaseVetorRijndael = FireBase.GetFireBaseData(EntradaFireBaseVetorRijndael);
                string vetorRijndael = RetornoFireBaseVetorRijndael.Body.Replace("\"", "");
                #endregion

                Entrada = Entrada.Replace("InfoTech2u", "/");

                #region Cryptography Level 3
                ParametroEntreda ParmatroParametroRijndael = new ParametroEntreda { cipherText = Convert.FromBase64String(Entrada), Key = Convert.FromBase64String(chaveRijndael), IV = Convert.FromBase64String(vetorRijndael), OrigemChamadaToken = HttpContext.Current.Request.Url.AbsoluteUri };
                DAO.Rijndael cryptRijndael = new DAO.Rijndael();
                string decryptedRijndael = cryptRijndael.DecryptRijndael(ParmatroParametroRijndael);
                #endregion

                #region Cryptography Level 2
                ParametroEntreda ParmatroParametroDES = new ParametroEntreda { cipherText = Convert.FromBase64String(decryptedRijndael), Key = Convert.FromBase64String(chaveDES), IV = Convert.FromBase64String(vetorDES), OrigemChamadaToken = HttpContext.Current.Request.Url.AbsoluteUri };
                DAO.DES cryptDES = new DAO.DES();
                string encryptedDES = cryptDES.DecryptAES(ParmatroParametroDES);
                #endregion

                #region Cryptography Level 1
                ParametroEntreda ParmatroParametroAES = new ParametroEntreda { cipherText = Convert.FromBase64String(encryptedDES), Key = Convert.FromBase64String(chaveAes), IV = Convert.FromBase64String(vetorAes), OrigemChamadaToken = HttpContext.Current.Request.Url.AbsoluteUri };
                DAO.AES cryptAES = new DAO.AES();
                string encryptedAES = cryptAES.DecryptAES(ParmatroParametroAES);
                #endregion

                ParametroRetorno Retorno = new ParametroRetorno { CodigoRetorno = HttpStatusCode.OK.ToString(), Mensagem = "Criptografia gerada com sucesso", Retorno = encryptedAES };
                return Request.CreateResponse(HttpStatusCode.OK, Retorno); ;
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possível criptografar a entrada: ", Entrada);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

    }
}