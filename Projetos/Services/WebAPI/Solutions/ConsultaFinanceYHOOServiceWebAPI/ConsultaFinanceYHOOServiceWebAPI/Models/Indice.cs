using System;
namespace ConsultaFinanceYHOOServiceWebAPI.Models
{
    public class Indice
    {
        public string change { get; set; }
        public string chg_percent { get; set; }
        public string day_high { get; set; }
        public string day_low { get; set; }
        public string issuer_name { get; set; }
        public string issuer_name_lang { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string symbol { get; set; }
        public string ts { get; set; }
        public string type { get; set; }
        public string utctime { get; set; }
        public string volume { get; set; }
        public string year_high { get; set; }
        public string year_low { get; set; }
    }
}