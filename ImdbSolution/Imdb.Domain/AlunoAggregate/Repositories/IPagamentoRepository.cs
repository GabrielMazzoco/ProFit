using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.Shared.Interfaces;

namespace IronFit.Domain.AlunoAggregate.Repositories
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        bool ExistePagamentoData(int mes, int ano, int idAluno);
    }
}
