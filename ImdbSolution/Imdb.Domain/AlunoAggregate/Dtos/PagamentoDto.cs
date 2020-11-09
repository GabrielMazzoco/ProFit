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
        public string Nome { get; set; }
        public string Modalidade { get; set; }
        public string Academia { get; set; }
    }
}
