using ApostasCEF.Models;
using System.Collections.Generic;

namespace ApostasCEF.ViewModels
{
    public class SorteioViewModel
    {
        public List<int> NumerosSorteados { get; set; }
        public List<Aposta> ListaApostasGanhadoras { get; set; }
    }
}