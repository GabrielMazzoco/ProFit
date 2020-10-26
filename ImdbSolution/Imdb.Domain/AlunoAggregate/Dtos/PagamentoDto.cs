namespace IronFit.Domain.AlunoAggregate.Dtos
{
    public class PagamentoDto
    {
        public decimal Valor { get; set; }
        public int IdAluno { get; set; }
        public int MesReferencia { get; set; }
        public int AnoReferencia { get; set; }
        public bool MesInteiro { get; set; }
        public int QuantidadeDias { get; set; }
    }
}
