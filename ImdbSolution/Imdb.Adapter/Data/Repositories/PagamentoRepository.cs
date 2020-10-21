using System.Linq;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.AlunoAggregate.Repositories;

namespace IronFit.Adapter.Data.Repositories
{
    public class PagamentoRepository : Repository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public bool ExistePagamentoData(int mes, int ano, int idAluno)
        {
            var existe = DbContext.Set<Pagamento>()
                .Any(x => x.IdAluno == idAluno &&
                          x.MesReferencia == mes &&
                          x.AnoReferencia == ano);

            return existe;
        }
    }
}
