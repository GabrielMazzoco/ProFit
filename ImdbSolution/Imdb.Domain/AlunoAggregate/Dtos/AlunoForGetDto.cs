using System;

namespace IronFit.Domain.AlunoAggregate.Dtos
{
    public class AlunoForGetDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modalidade { get; set; }
        public int IdModalidade { get; set; }
        public bool MesAtualQuitado { get; set; }
        public decimal Valor { get; set; }
        public string DataProximoPagamento { get; set; }
        public DateTime DataProximoPag { get; set; }
        public bool Active { get; set; }
    }
}
