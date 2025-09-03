using BNP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Application.Interfaces
{
    public interface IMovimentoManualAppService
    {
        IEnumerable<object> Listar(int mes, int ano);
        void Criar(MovimentoManualDto dto, string usuarioFixo = "TESTE");
    }
}
