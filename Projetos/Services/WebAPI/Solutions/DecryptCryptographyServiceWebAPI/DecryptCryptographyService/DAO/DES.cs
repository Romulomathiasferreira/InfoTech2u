using System;
using System.Security.Cryptography;
using System.IO;
using DecryptCryptographyService.Models;

namespace DecryptCryptographyService.DAO
{
    public class DES
    {
        public string DecryptAES(ParametroEntreda Entrada)
        {
            if (Entrada.cipherText == null || Entrada.cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Entrada.Key == null || Entrada.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Entrada.IV == null || Entrada.IV.Length <= 0)
                throw new ArgumentNullException("Key");
            Entrada.plainText = null;
            using (TripleDESCryptoServiceProvider tdsAlg = new TripleDESCryptoServiceProvider())
            {
                tdsAlg.Key = Entrada.Key;
                tdsAlg.IV = Entrada.IV;
                ICryptoTransform decryptor = tdsAlg.CreateDecryptor(tdsAlg.Key, tdsAlg.IV);
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