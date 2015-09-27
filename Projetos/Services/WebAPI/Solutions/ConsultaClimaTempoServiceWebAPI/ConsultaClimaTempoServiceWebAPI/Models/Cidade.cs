using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaClimaTempoServiceWebAPI.Models
{
    public class Cidade
    {
        public string Nome { get; set; }
        public string Uf { get; set; }
        public string Atualizacao { get; set; }

        public List<Previsao> listPrevisao { get; set; }

    }
}