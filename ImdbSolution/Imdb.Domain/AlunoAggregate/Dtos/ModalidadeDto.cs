namespace IronFit.Domain.AlunoAggregate.Dtos
{
    public class ModalidadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorPadrao { get; set; }
        public bool Active { get; set; } = true;
    }
}
