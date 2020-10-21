using System.Linq;
using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.AlunoAggregate.Repositories;

namespace IronFit.Adapter.Data.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public Aluno AlunoExiste(AlunoDto alunoDto)
        {
            var aluno = DbContext.Set<Aluno>()
                .FirstOrDefault(x => x.Nome.ToLower() == alunoDto.Nome.ToLower() &&
                                     x.DataNascimento.Date == alunoDto.DataNascimento.Date);

            return aluno;
        }
    }
}
