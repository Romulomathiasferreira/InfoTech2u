using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using DecryptCryptographyService.Models;

namespace DecryptCryptographyService.DAO
{
    public class FireBase
    {
        public static FireBaseRetorno GetFireBaseData(FireBaseEntrada Entrada)
        {
            IFirebaseConfig config = new FirebaseConfig { AuthSecret = Entrada.AuthSecret, BasePath = Entrada.BasePath };
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = client.Get(Entrada.item.ToString());
            FireBaseRetorno retorno = new FireBaseRetorno { StatusCode = response.StatusCode.ToString(), Body = response.Body };
            retorno.StatusCode = response.StatusCode.ToString();
            retorno.Body = response.Body;
            return retorno;
        }
    }
}