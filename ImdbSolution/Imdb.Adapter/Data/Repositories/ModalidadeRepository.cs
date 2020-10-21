using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.AlunoAggregate.Repositories;

namespace IronFit.Adapter.Data.Repositories
{
    public class ModalidadeRepository : Repository<Modalidade>, IModalidadeRepository
    {
        public ModalidadeRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
