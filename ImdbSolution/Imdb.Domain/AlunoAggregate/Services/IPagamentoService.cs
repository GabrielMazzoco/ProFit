using IronFit.Domain.AlunoAggregate.Dtos;

namespace IronFit.Domain.AlunoAggregate.Services
{
    public interface IPagamentoService
    {
        void RealizarPagamento(PagamentoDto pagamentoDto);
    }
}
