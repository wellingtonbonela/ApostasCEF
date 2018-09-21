using System.Collections.Generic;

namespace ApostasCEF.Models.Interfaces
{
    public interface IJogo
    {
        int QuantidadeNumerosAposta { get; }
        int QuantidadeNumerosDisponiveis { get; }

        List<int> Sortear();
        List<Aposta> ApurarGanhadores(List<Aposta> listaApostas);
        List<int> GerarApostaAutomatica();
    }
}
