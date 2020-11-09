using System;
using System.Collections.Generic;
using IronFit.Domain.Shared.Entities;

namespace IronFit.Domain.AlunoAggregate.Entidades
{
    public class Aluno : Entity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public DateTime DataMatricula { get; set; }
        public string Ddd { get; set; }
        public string NumeroTelefone { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }

        //Fks
        public int IdModalidade { get; set; }

        public virtual Modalidade Modalidade { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
