using ApostasCEF.Models;
using ApostasCEF.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using static ApostasCEF.Enumeradores.Enumeradores;

namespace ApostasCEF.Controllers
{
    public class LoteriaController : Controller
    {
        public List<Aposta> ListaApostas
        {
            get
            {
                if (TempData["ListaApostas"] == null)
                    TempData["ListaApostas"] = new List<Aposta>();

                return (List<Aposta>)TempData["ListaApostas"];
            }
            set { TempData["ListaApostas"] = value; }
        }

        public ActionResult Index()
        {
            return View("~/Views/Loteria/Index.cshtml");
        }

        public ActionResult Jogar()
        {
            var objJogo = JogoFactory.Criar(TipoJogo.MegaSena);
            var viewModel = new JogoViewModel
            {
                QuantidadeNumerosAposta = objJogo.QuantidadeNumerosAposta,
                QuantidadeNumerosDisponiveis = objJogo.QuantidadeNumerosDisponiveis
            };

            return View("~/Views/Loteria/Jogar.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult SalvarAposta(List<int> numerosSelecionados)
        {
            var aposta = new Aposta
            {
                Identificador = Guid.NewGuid().ToString(),
                DataHora = DateTime.Now,
                NumerosEscolhidos = numerosSelecionados
            };

            this.ListaApostas.Add(aposta);
            TempData.Keep("ListaApostas");

            return RedirectToAction("Jogar");
        }

        public ActionResult GerarAposta()
        {
            var objJogo = JogoFactory.Criar(TipoJogo.MegaSena);
            var numerosAutomaticos = objJogo.GerarApostaAutomatica();

            return SalvarAposta(numerosAutomaticos);
        }

        public ActionResult Sortear()
        {
            var objJogo = JogoFactory.Criar(TipoJogo.MegaSena);

            var viewModel = new SorteioViewModel
            {
                NumerosSorteados = objJogo.Sortear(),
                ListaApostasGanhadoras = objJogo.ApurarGanhadores(this.ListaApostas)
            };

            return View("~/Views/Loteria/Sorteio.cshtml", viewModel);
        }
    }
}