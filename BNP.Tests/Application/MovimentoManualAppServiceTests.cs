using BNP.Application.DTOs;
using BNP.Application.Services;
using BNP.Domain.Entities;
using BNP.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Tests.Application
{
    [TestClass]
    public class MovimentoManualAppServiceTests
    {
        private Mock<IMovimentoManualRepository> _repoMock;
        private MovimentoManualAppService _service;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<IMovimentoManualRepository>();
            _service = new MovimentoManualAppService(_repoMock.Object);
        }

        [TestMethod]
        public void Criar_DeveGerarNumeroLancamentoCorretoESalvar()
        {
            var dto = new MovimentoManualDto
            {
                Mes = 9,
                Ano = 2025,
                CodigoProduto = "P001",
                CodigoCosif = "C001",
                Descricao = "Teste",
                Valor = 100.0m
            };

            _repoMock.Setup(r => r.ObterProximoNumeroLancamento(9, 2025)).Returns(7);

            _service.Criar(dto, "TESTE");

            _repoMock.Verify(r => r.Adicionar(It.Is<MovimentoManual>(
                m => m.NumeroLancamento == 7 &&
                     m.CodigoProduto == "P001" &&
                     m.Descricao == "Teste"
            )), Times.Once);

            _repoMock.Verify(r => r.Salvar(), Times.Once);
        }

        [TestMethod]
        public void Listar_DeveRetornarMovimentosPorMesAno()
        {
            var lista = new List<MovimentoManual>
            {
                new MovimentoManual
                {
                    Mes = 9,
                    Ano = 2025,
                    NumeroLancamento = 1,
                    CodigoProduto = "P001",
                    CodigoCosif = "C001",
                    Descricao = "OK",
                    Valor = 123.45m,
                    Usuario = "TESTE",
                    DataMovimento = DateTime.Now
                }
            };

            _repoMock.Setup(r => r.ObterPorMesAno(9, 2025)).Returns(lista);

            var result = _service.Listar(9, 2025);

            Assert.AreEqual(1, result is IEnumerable<object> enumerable ? enumerable.Count() : 0);
        }
    }
}
