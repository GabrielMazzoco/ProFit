using System.Collections.Generic;
using System.Linq;
using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.AlunoAggregate.Repositories;
using Microsoft.AspNetCore.Http;

namespace IronFit.Adapter.Data.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        private readonly IHttpContextAccessor _httpContext;

        public AlunoRepository(DataContext dbContext, IHttpContextAccessor httpContext) : base(dbContext)
        {
            _httpContext = httpContext;
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
            var idsAcademias = ObterIdsAcademias();

            var query = DbContext.Set<Aluno>().AsQueryable();

            query = query.Where(x => idsAcademias.Contains(x.Modalidade.IdAcademia));

            if (!string.IsNullOrEmpty(nome)) query = query.Where(x => x.Nome.ToLower().Contains(nome.ToLower()));

            var result = query.Select(x => new AlunoForGetDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Modalidade = x.Modalidade.Nome,
                IdModalidade = x.IdModalidade,
                Active = x.Active
            }).ToList();

            return result;
        }

        private IEnumerable<int> ObterIdsAcademias()
        {
            var academias = _httpContext.HttpContext.User.FindFirst("Academias").Value;

            var idAcademias = academias.Split(",").Select(int.Parse);

            return idAcademias;
        }
    }
}
