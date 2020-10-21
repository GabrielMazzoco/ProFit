using System;
using IronFit.Domain.Shared.Entities;

namespace IronFit.Domain.AlunoAggregate.Entidades
{
    public class Pagamento : Entity
    {
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public int MesReferencia { get; set; }
        public int AnoReferencia { get; set; }

        public int IdAluno { get; set; }

        public virtual Aluno Aluno { get; set; }
    }
}
