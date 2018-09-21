using ApostasCEF.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApostasCEF.Models
{
    public class MegaSena : Jogo, IJogo
    {
        public int QuantidadeNumerosAposta { get { return 6; } }
        public int QuantidadeNumerosDisponiveis { get { return 60; } }

        public List<int> Sortear()
        {
            var listaNumerosSorteados = new List<int>();

            var random = new Random();
            while (listaNumerosSorteados.Count < QuantidadeNumerosAposta)
            {
                int numeroSorteado = GerarNumero(1, QuantidadeNumerosDisponiveis);
                if (!listaNumerosSorteados.Contains(numeroSorteado))
                    listaNumerosSorteados.Add(numeroSorteado);
            }

            return listaNumerosSorteados;
        }

        public List<int> GerarApostaAutomatica()
        {
            var listaNumerosSorteados = new List<int>();

            var random = new Random();
            while (listaNumerosSorteados.Count < QuantidadeNumerosAposta)
            {
                int numeroSorteado = GerarNumero(1, QuantidadeNumerosDisponiveis);
                if (!listaNumerosSorteados.Contains(numeroSorteado))
                    listaNumerosSorteados.Add(numeroSorteado);
            }

            return listaNumerosSorteados;
        }

        public List<Aposta> ApurarGanhadores(List<Aposta> listaApostas)
        {
            var numerosSorteados = Sortear();

            var listaApostasGanhadoras = new List<Aposta>();
            foreach (Aposta aposta in listaApostas)
            {
                foreach (int numero in numerosSorteados)
                {
                    if (aposta.NumerosEscolhidos.Contains(numero))
                        aposta.TotalAcertos++;
                }
            }

            listaApostasGanhadoras = listaApostas.Where(a => a.TotalAcertos > 3).ToList();

            return listaApostasGanhadoras;
        }
    }
}