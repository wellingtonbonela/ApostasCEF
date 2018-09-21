using System;
using System.Collections.Generic;

namespace ApostasCEF.Models
{
    public class Aposta
    {
        public string Identificador { get; set; }
        public DateTime DataHora { get; set; }
        public List<int> NumerosEscolhidos { get; set; }
        public int TotalAcertos { get; set; }
    }
}