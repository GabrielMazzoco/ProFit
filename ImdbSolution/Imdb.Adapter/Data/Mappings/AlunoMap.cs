using IronFit.Domain.AlunoAggregate.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IronFit.Adapter.Data.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.DataNascimento).IsRequired();

            builder.Property(x => x.Cpf).IsRequired(false);

            builder.Property(x => x.DataMatricula).IsRequired();

            builder.Property(x => x.IdModalidade).IsRequired();

            builder.HasOne(x => x.Modalidade)
                .WithMany(x => x.Alunos)
                .HasForeignKey(x => x.IdModalidade);
        }
    }
}
