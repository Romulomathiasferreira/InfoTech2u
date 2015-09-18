using System;
using System.Security.Cryptography;
using System.IO;
using DecryptCryptographyService.Models;

namespace DecryptCryptographyService.DAO
{
    public class AES
    {
        public string DecryptAES(ParametroEntreda Entrada)
        {
            if (Entrada.cipherText == null || Entrada.cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Entrada.Key == null || Entrada.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Entrada.IV == null || Entrada.IV.Length <= 0)
                throw new ArgumentNullException("Key");
            Entrada.plainText= null;
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Entrada.Key;
                aesAlg.IV = Entrada.IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(Entrada.cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            Entrada.plainText = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            return Entrada.plainText;
        }
    }
}