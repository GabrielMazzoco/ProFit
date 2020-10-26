using System.Collections.Generic;
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

        public IEnumerable<AlunoForGetDto> GetAlunos(string nome)
        {
            var query = DbContext.Set<Aluno>().AsQueryable();

            if (!string.IsNullOrEmpty(nome)) query = query.Where(x => x.Nome.ToLower().Contains(nome.ToLower()));

            var result = query.Select(x => new AlunoForGetDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Modalidade = x.Modalidade.Nome,
                Active = x.Active
            }).ToList();

            return result;
        }
    }
}
