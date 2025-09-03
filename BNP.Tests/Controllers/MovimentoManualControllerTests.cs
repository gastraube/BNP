using BNP.Application.Interfaces;
using BNP.Domain.Interfaces;
using BNP.Web.Controllers;
using BNP.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BNP.Tests.Controllers
{
    [TestClass]
    public class MovimentoManualControllerTests
    {
        private Mock<IMovimentoManualAppService> _appMock;
        private Mock<IProdutoRepository> _prodMock;
        private Mock<IProdutoCosifRepository> _cosifMock;
        private MovimentoManualController _controller;

        [TestInitialize]
        public void Setup()
        {
            _appMock = new Mock<IMovimentoManualAppService>();
            _prodMock = new Mock<IProdutoRepository>();
            _cosifMock = new Mock<IProdutoCosifRepository>();

            _controller = new MovimentoManualController(
                _appMock.Object,
                _prodMock.Object,
                _cosifMock.Object
            );
        }

        [TestMethod]
        public void Index_DeveRetornarViewComModelPreenchido()
        {
            // Arrange
            _appMock.Setup(x => x.Listar(1, 2025)).Returns(new List<object>());
            _prodMock.Setup(x => x.ObterTodos()).Returns(new List<Domain.Entities.Produto>
            {
                new Domain.Entities.Produto { Codigo = "P001", Descricao = "Produto 1" }
            });

            // Act
            var result = _controller.Index(1, 2025) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = result.Model as MovimentoManualViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Mes);
            Assert.AreEqual(2025, model.Ano);
        }

        [TestMethod]
        public void Create_DeveRedirecionarParaIndex()
        {
            // Arrange
            var vm = new MovimentoManualViewModel
            {
                Mes = 9,
                Ano = 2025,
                CodigoProduto = "P001",
                CodigoCosif = "C001",
                Valor = 100,
                Descricao = "Teste"
            };

            // Act
            var result = _controller.Create(vm) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(9, result.RouteValues["mes"]);
            Assert.AreEqual(2025, result.RouteValues["ano"]);
        }
    }
}
