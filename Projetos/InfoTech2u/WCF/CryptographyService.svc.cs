using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using Cryptography;

namespace WCF
{
    public class CryptographyService : ICryptographyService
    {
        public byte[] AESCryptography(string entrada, byte[] chave, byte[] vetor)
        {
            Cryptography.AES crypt = new Cryptography.AES();
            byte[] encrypted = crypt.EncryptStringToBytes_Aes(entrada, chave, vetor);
            return encrypted;
        }

        public string AESDescryptography(byte[] entrada, byte[] chave, byte[] vetor)
        {
            Cryptography.AES crypt = new Cryptography.AES();
            string roundtrip = crypt.DecryptStringFromBytes_Aes(entrada, chave, vetor);
            return roundtrip;
        }

        public byte[] DESCryptography(string entrada, byte[] chave, byte[] vetor)
        {
            Cryptography.DES crypt = new Cryptography.DES();
            byte[] encrypted = crypt.EncryptStringToBytes(entrada, chave, vetor);
            return encrypted;
        }

        public string DESDescryptography(byte[] entrada, byte[] chave, byte[] vetor)
        {
            Cryptography.DES crypt = new Cryptography.DES();
            string roundtrip = crypt.DecryptStringFromBytes(entrada, chave, vetor);
            return roundtrip;
        }

        public byte[] RijndaelCryptography(string entrada, byte[] chave, byte[] vetor)
        {
            Cryptography.Rijndael crypt = new Cryptography.Rijndael();
            byte[] encrypted = crypt.EncryptStringToBytes(entrada, chave, vetor);
            return encrypted;
        }

        public string RijndaelDescryptography(byte[] entrada, byte[] chave, byte[] vetor)
        {
            Cryptography.Rijndael crypt = new Cryptography.Rijndael();
            string roundtrip = crypt.DecryptStringFromBytes(entrada, chave, vetor);
            return roundtrip;
        }

        public string EncryptCryptographyService(string entrada)
        {
            #region Get Keys and Vectors in Firebase
            FireBaseGenericService firebase = new FireBaseGenericService();
            string chaveAes = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "AES/KEY").Replace("\"", "");
            string vetorAes = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "AES/VECTOR").Replace("\"", "");
            string chaveDES = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "DES/KEY").Replace("\"", "");
            string vetorDES = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "DES/VECTOR").Replace("\"", "");
            string chaveRijndael = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "RIJNDAEL/KEY").Replace("\"", "");
            string vetorRijndael = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "RIJNDAEL/VECTOR").Replace("\"", "");
            #endregion

            #region Cryptography Level 1
            Cryptography.AES cryptAES = new Cryptography.AES();
            string encryptedAES = Convert.ToBase64String(cryptAES.EncryptStringToBytes_Aes(entrada, Convert.FromBase64String(chaveAes), Convert.FromBase64String(vetorAes)));
            #endregion

            #region Cryptography Level 2
            Cryptography.DES cryptDES = new Cryptography.DES();
            string encryptedDES = Convert.ToBase64String(cryptDES.EncryptStringToBytes(encryptedAES, Convert.FromBase64String(chaveDES), Convert.FromBase64String(vetorDES)));
            #endregion

            #region Cryptography Level 3
            Cryptography.Rijndael cryptRijndael = new Cryptography.Rijndael();
            string encryptedRijndael = Convert.ToBase64String(cryptRijndael.EncryptStringToBytes(encryptedDES, Convert.FromBase64String(chaveRijndael), Convert.FromBase64String(vetorRijndael)));
            #endregion

            return encryptedRijndael;
        }

        public string DecryptCryptographyService(string entrada)
        {
            #region Get Keys and Vectors in Firebase
            FireBaseGenericService firebase = new FireBaseGenericService();
            string chaveAes = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "AES/KEY").Replace("\"", "");
            string vetorAes = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "AES/VECTOR").Replace("\"", "");
            string chaveDES = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "DES/KEY").Replace("\"", "");
            string vetorDES = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "DES/VECTOR").Replace("\"", "");
            string chaveRijndael = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "RIJNDAEL/KEY").Replace("\"", "");
            string vetorRijndael = firebase.GetFireBaseData("iY8kzmEr6cvEhTo6fdYbKDsdVAD4xJZR46NdGsGf", "https://cryptography.firebaseio.com/", "RIJNDAEL/VECTOR").Replace("\"", "");
            #endregion

            #region Cryptography Level 3
            Cryptography.Rijndael cryptRijndael = new Cryptography.Rijndael();
            string decryptedRijndael = cryptRijndael.DecryptStringFromBytes(Convert.FromBase64String(entrada), Convert.FromBase64String(chaveRijndael), Convert.FromBase64String(vetorRijndael));
            #endregion

            #region Cryptography Level 2
            Cryptography.DES cryptDES = new Cryptography.DES();
            string decryptedDES = cryptDES.DecryptStringFromBytes(Convert.FromBase64String(decryptedRijndael), Convert.FromBase64String(chaveDES), Convert.FromBase64String(vetorDES));
            #endregion

            #region Cryptography Level 1
            Cryptography.AES cryptAES = new Cryptography.AES();
            string decryptedAES = cryptAES.DecryptStringFromBytes_Aes(Convert.FromBase64String(decryptedDES), Convert.FromBase64String(chaveAes), Convert.FromBase64String(vetorAes));
            #endregion

            return decryptedAES;
        }
    }
}
