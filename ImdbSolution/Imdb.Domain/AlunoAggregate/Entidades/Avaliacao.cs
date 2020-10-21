using System;
using IronFit.Domain.Shared.Entities;

namespace IronFit.Domain.AlunoAggregate.Entidades
{
    public class Avaliacao : Entity
    {
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal PercentualGordura { get; set; }
        // Medidas que eu nao lembro todas
        public DateTime DataAvaliacao { get; set; }

        public int IdAluno { get; set; }

        public virtual Aluno Aluno { get; set; }
    }
}
