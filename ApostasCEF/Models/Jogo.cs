using System;

namespace ApostasCEF.Models
{
    public class Jogo
    {
        public int GerarNumero(int inicio, int fim)
        {
            var random = new Random();
            return random.Next(inicio, fim);
        }
    }
}