using System.Collections.Generic;
using System.Linq;
using IronFit.Domain.AlunoAggregate.Dtos;
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

        public IEnumerable<PagamentoDto> GetPagamentos(string aluno)
        {
            var query = DbContext.Set<Pagamento>().AsQueryable();

            if (string.IsNullOrEmpty(aluno))
            {
                return null;
            }

            query = query.Where(x => x.Aluno.Nome.ToLower().Contains(aluno.ToLower()));

            var result = query.Select(x => new PagamentoDto
            {
                Nome = x.Aluno.Nome,
                MesReferencia = x.MesReferencia,
                AnoReferencia = x.AnoReferencia,
                Modalidade = x.Aluno.Modalidade.Nome,
                Academia = x.Aluno.Modalidade.IdAcademia == 1 ? "IronFit" : "ProFit"
            }).OrderByDescending(x => x.AnoReferencia).ThenByDescending(x => x.MesReferencia).ToList();

            return result;
        }
    }
}
