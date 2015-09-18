using System;
using System.IO;
using System.Security.Cryptography;
using EncryptCryptographyServiceWebAPI.Models;

namespace EncryptCryptographyServiceWebAPI.DAO
{
    public class Rijndael
    {
        public byte[] EncryptRijndael(ParametroEntreda Entrada)
        {
            if (Entrada.plainText == null || Entrada.plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Entrada.Key == null || Entrada.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Entrada.IV == null || Entrada.IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Entrada.Key;
                rijAlg.IV = Entrada.IV;
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
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