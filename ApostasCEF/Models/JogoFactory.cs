using ApostasCEF.Models.Interfaces;
using static ApostasCEF.Enumeradores.Enumeradores;

namespace ApostasCEF.Models
{
    public class JogoFactory
    {
        public static IJogo Criar(TipoJogo tipoJogo)
        {
            IJogo objJogo;
            switch (tipoJogo)
            {
                case TipoJogo.MegaSena:
                    objJogo = new MegaSena();
                    break;
                default:
                    objJogo = null;
                    break;
            }

            return objJogo;
        }
    }
}