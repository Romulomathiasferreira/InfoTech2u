using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaClimaTempoServiceWebAPI.Models
{
    public class Previsao
    {
        public string Dia { get; set; }
        public string Tempo { get; set; }
        public string Maxima { get; set; }
        public string Minima { get; set; }
        public string IUV { get; set; }
    }
}