using BNP.Application.DTOs;
using BNP.Application.Interfaces;
using BNP.Domain.Interfaces;
using BNP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BNP.Web.Controllers
{
    public class MovimentoManualController : Controller
    {
        private readonly IMovimentoManualAppService _app;
        private readonly IProdutoRepository _prodRep;
        private readonly IProdutoCosifRepository _cosifRep;

        public MovimentoManualController(
            IMovimentoManualAppService app,
            IProdutoRepository prodRep,
            IProdutoCosifRepository cosifRep)
        {
            _app = app; _prodRep = prodRep; _cosifRep = cosifRep;
        }

        [HttpGet]
        public ActionResult Index(int mes = 1, int ano = 2025)
        {
            var gridData = _app.Listar(mes, ano)
            .Select(x => new MovimentoManualGridItemViewModel
            {
                NumeroLancamento = (int)x.GetType().GetProperty("NumeroLancamento").GetValue(x),
                CodigoProduto = (string)x.GetType().GetProperty("CodigoProduto").GetValue(x),
                CodigoCosif = (string)x.GetType().GetProperty("CodigoCosif").GetValue(x),
                Descricao = (string)x.GetType().GetProperty("Descricao").GetValue(x),
                Valor = (decimal)x.GetType().GetProperty("Valor").GetValue(x),
                Usuario = (string)x.GetType().GetProperty("Usuario").GetValue(x),
                DataMovimento = (DateTime)x.GetType().GetProperty("DataMovimento").GetValue(x),
            }).ToList();

            var vm = new MovimentoManualViewModel
            {
                Mes = mes,
                Ano = ano,
                Grid = gridData,
                Produtos = _prodRep.ObterTodos().Select(p => new SelectListItem
                {
                    Value = p.Codigo,
                    Text = p.Descricao
                })
            };

            vm.Cosifs = Enumerable.Empty<SelectListItem>();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovimentoManualViewModel vm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", new { mes = vm.Mes, ano = vm.Ano });

            _app.Criar(new MovimentoManualDto
            {
                Mes = vm.Mes,
                Ano = vm.Ano,
                CodigoProduto = vm.CodigoProduto,
                CodigoCosif = vm.CodigoCosif,
                Descricao = vm.Descricao,
                Valor = vm.Valor
            });

            return RedirectToAction("Index", new { mes = vm.Mes, ano = vm.Ano });
        }

        [HttpGet]
        public JsonResult CosifsPorProduto(string codProduto)
        {
            var data = _cosifRep.ObterPorProduto(codProduto)
                        .Select(c => new { value = c.CodigoCosif, text = c.CodigoCosif + " (" + c.CodigoClassificacao + ")" });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}