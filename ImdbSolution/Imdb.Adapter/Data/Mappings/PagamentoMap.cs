using IronFit.Domain.AlunoAggregate.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IronFit.Adapter.Data.Mappings
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataPagamento).IsRequired();

            builder.Property(x => x.Valor).IsRequired();

            builder.Property(x => x.MesReferencia).IsRequired();

            builder.Property(x => x.AnoReferencia).IsRequired();

            builder.Property(x => x.QuantidadeDias).IsRequired();

            builder.Property(x => x.IdAluno).IsRequired();

            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.Pagamentos)
                .HasForeignKey(x => x.IdAluno);
        }
    }
}
