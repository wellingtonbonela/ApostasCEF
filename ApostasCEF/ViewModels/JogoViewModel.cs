using System.Collections.Generic;

namespace ApostasCEF.ViewModels
{
    public class JogoViewModel
    {
        public int QuantidadeNumerosAposta { get; set; }
        public int QuantidadeNumerosDisponiveis { get; set; }
        public List<int> NumerosEscolhidos { get; set; }
    }
}