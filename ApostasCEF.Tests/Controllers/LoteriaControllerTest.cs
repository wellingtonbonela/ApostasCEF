using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApostasCEF;
using ApostasCEF.Controllers;
using ApostasCEF.ViewModels;

namespace ApostasCEF.Tests.Controllers
{
    [TestClass]
    public class LoteriaControllerTest
    {
        [TestMethod]
        public void Jogar()
        {
            // Arrange
            LoteriaController controller = new LoteriaController();

            // Act
            ViewResult result = controller.Jogar() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Sortear()
        {
            // Arrange
            LoteriaController controller = new LoteriaController();

            // Act
            ViewResult result = controller.Sortear() as ViewResult;

            // Assert
            Assert.IsTrue(((SorteioViewModel)result.Model).NumerosSorteados.Count == 6, "Números sorteados corretamente!");
        }
    }
}
