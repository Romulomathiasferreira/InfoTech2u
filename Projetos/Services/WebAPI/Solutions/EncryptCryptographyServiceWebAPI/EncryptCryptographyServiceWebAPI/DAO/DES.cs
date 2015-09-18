using System;
using System.IO;
using System.Security.Cryptography;
using EncryptCryptographyServiceWebAPI.Models;

namespace EncryptCryptographyServiceWebAPI.DAO
{
    public class DES
    {
        public byte[] EncryptDES(ParametroEntreda Entrada)
        {
            if (Entrada.plainText == null || Entrada.plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Entrada.Key == null || Entrada.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Entrada.IV == null || Entrada.IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            using (TripleDESCryptoServiceProvider tdsAlg = new TripleDESCryptoServiceProvider())
            {
                tdsAlg.Key = Entrada.Key;
                tdsAlg.IV = Entrada.IV;
                ICryptoTransform encryptor = tdsAlg.CreateEncryptor(tdsAlg.Key, tdsAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(Entrada.plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
    }
}