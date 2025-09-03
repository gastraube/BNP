using BNP.Application.DTOs;
using BNP.Application.Interfaces;
using BNP.Domain.Entities;
using BNP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Application.Services
{
    public class MovimentoManualAppService : IMovimentoManualAppService
    {
        private readonly IMovimentoManualRepository _rep;

        public MovimentoManualAppService(IMovimentoManualRepository rep)
        {
            _rep = rep;
        }

        public IEnumerable<object> Listar(int mes, int ano) =>
            _rep.ObterPorMesAno(mes, ano)
                .Select(m => new {
                    m.Mes,
                    m.Ano,
                    m.NumeroLancamento,
                    m.CodigoProduto,
                    m.CodigoCosif,
                    m.Descricao,
                    m.Valor,
                    m.DataMovimento,
                    m.Usuario
                }).ToList();

        public void Criar(MovimentoManualDto dto, string usuarioFixo = "TESTE")
        {
            var numero = _rep.ObterProximoNumeroLancamento(dto.Mes, dto.Ano);

            var entidade = new MovimentoManual
            {
                Mes = dto.Mes,
                Ano = dto.Ano,
                NumeroLancamento = numero,
                CodigoProduto = dto.CodigoProduto,
                CodigoCosif = dto.CodigoCosif,
                Descricao = dto.Descricao,
                Valor = dto.Valor,
                DataMovimento = DateTime.Now,
                Usuario = usuarioFixo
            };

            _rep.Adicionar(entidade);
            _rep.Salvar();
        }
    }
}
