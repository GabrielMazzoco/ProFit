using System.Collections.Generic;
using IronFit.Domain.AlunoAggregate.Dtos;

namespace IronFit.Domain.AlunoAggregate.Services
{
    public interface IPagamentoService
    {
        void RealizarPagamento(PagamentoDto pagamentoDto);
        IEnumerable<PagamentoDto> GetPagamentos(string aluno);
    }
}
