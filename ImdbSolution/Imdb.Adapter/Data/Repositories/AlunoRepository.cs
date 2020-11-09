using System;
using System.Collections.Generic;
using System.Linq;
using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.AlunoAggregate.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<AlunoForGetDto> GetAlunos(string nome, int status)
        {
            var idsAcademias = ObterIdsAcademias();

            var query = DbContext.Set<Aluno>().Include(x => x.Pagamentos).Include(x => x.Modalidade).AsQueryable();

            query = query.Where(x => idsAcademias.Contains(x.Modalidade.IdAcademia));

            query = !string.IsNullOrEmpty(nome)
                ? query.Where(x => x.Nome.ToLower().Contains(nome.ToLower()))
                : query.Where(x => x.Active);

            var resultDb = query.ToList();

            var result = resultDb.Select(x => new AlunoForGetDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Modalidade = x.Modalidade.Nome,
                IdModalidade = x.IdModalidade,
                Active = x.Active,
                Valor = x.Pagamentos != null && x.Pagamentos.Any() ? x.Pagamentos.Last().Valor : x.Modalidade.ValorPadrao,
                DataProximoPag = x.Pagamentos != null && x.Pagamentos.Any()
                    ? new DateTime(x.Pagamentos.Last().AnoReferencia, x.Pagamentos.Last().MesReferencia,
                        x.DataMatricula.Day).AddMonths(1)
                    : x.DataMatricula
            }).ToList();

            switch (status)
            {
                case -1:
                    result = result.Where(x => x.DataProximoPag.Date <= DateTime.Now.Date).ToList();
                    break;
                case 1:
                    result = result.Where(x => x.DataProximoPag.Date > DateTime.Now.Date).ToList();
                    break;
            }

            foreach (var item in result)
            {
                item.DataProximoPagamento = item.DataProximoPag.ToString("dd/MM/yyyy");
            }

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
