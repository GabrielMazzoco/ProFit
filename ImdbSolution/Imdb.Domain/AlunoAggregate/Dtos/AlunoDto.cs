using System;

namespace IronFit.Domain.AlunoAggregate.Dtos
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public DateTime DataMatricula { get; set; }

        public int IdModalidade { get; set; }

        public bool Active { get; set; } = true;
    }
}
