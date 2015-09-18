using System;
using System.Security.Cryptography;
using System.IO;
using DecryptCryptographyService.Models;

namespace DecryptCryptographyService.DAO
{
    public class Rijndael
    {
        public string DecryptRijndael(ParametroEntreda Entrada)
        {

            if (Entrada.cipherText == null || Entrada.cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Entrada.Key == null || Entrada.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Entrada.IV == null || Entrada.IV.Length <= 0)
                throw new ArgumentNullException("IV");
            Entrada.plainText = null;
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Entrada.Key;
                rijAlg.IV = Entrada.IV;
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
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