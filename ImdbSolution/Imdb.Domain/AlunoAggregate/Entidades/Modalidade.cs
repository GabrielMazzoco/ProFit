using System.Collections.Generic;
using IronFit.Domain.Shared.Entities;

namespace IronFit.Domain.AlunoAggregate.Entidades
{
    public class Modalidade : Entity
    {
        public string Nome { get; set; }
        public decimal ValorPadrao { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
