using System.Collections.Generic;
using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.Shared.Interfaces;

namespace IronFit.Domain.AlunoAggregate.Repositories
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        bool ExistePagamentoData(int mes, int ano, int idAluno);
        IEnumerable<PagamentoDto> GetPagamentos(string aluno);
    }
}
