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
        public string Ddd { get; set; }
        public string NumeroTelefone { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }

        public int IdModalidade { get; set; }

        public bool Active { get; set; } = true;
    }
}
