﻿namespace DecryptCryptographyService.Models
{
    public class ParametroEntreda
    {
        public string OrigemChamadaToken { get; set; }

        public string plainText { get; set; }

        public byte[] Key { get; set; }

        public byte[] IV { get; set; }

        public byte[] cipherText { get; set; }

    }
}