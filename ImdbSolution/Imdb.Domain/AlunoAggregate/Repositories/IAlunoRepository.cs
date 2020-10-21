using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.Shared.Interfaces;

namespace IronFit.Domain.AlunoAggregate.Repositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Aluno AlunoExiste(AlunoDto alunoDto);
    }
}
