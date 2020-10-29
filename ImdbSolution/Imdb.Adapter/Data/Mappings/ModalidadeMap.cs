using IronFit.Domain.AlunoAggregate.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IronFit.Adapter.Data.Mappings
{
    public class ModalidadeMap : IEntityTypeConfiguration<Modalidade>
    {
        public void Configure(EntityTypeBuilder<Modalidade> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.ValorPadrao)
                .IsRequired();

            builder.Property(x => x.IdAcademia)
                .IsRequired();
        }
    }
}
