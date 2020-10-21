using IronFit.Domain.AlunoAggregate.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IronFit.Adapter.Data.Mappings
{
    public class AvaliacaoMap : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Peso).IsRequired();

            builder.Property(x => x.Altura).IsRequired();

            builder.Property(x => x.PercentualGordura).IsRequired();

            builder.Property(x => x.DataAvaliacao).IsRequired();

            builder.Property(x => x.IdAluno).IsRequired();

            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.Avaliacoes)
                .HasForeignKey(x => x.IdAluno);
        }
    }
}
