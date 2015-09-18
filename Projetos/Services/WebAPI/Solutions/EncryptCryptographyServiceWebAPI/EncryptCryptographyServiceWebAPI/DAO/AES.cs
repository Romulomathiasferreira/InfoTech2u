using System;
using System.Security.Cryptography;
using System.IO;
using EncryptCryptographyServiceWebAPI.Models;

namespace EncryptCryptographyServiceWebAPI.DAO
{
    public class AES
    {
        public byte[] EncryptAES(ParametroEntreda Entrada)
        {
            if (Entrada.plainText == null || Entrada.plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Entrada.Key == null || Entrada.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Entrada.IV == null || Entrada.IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Entrada.Key;
                aesAlg.IV = Entrada.IV;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
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