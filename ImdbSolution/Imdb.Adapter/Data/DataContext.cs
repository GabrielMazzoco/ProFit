using IronFit.Adapter.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace IronFit.Adapter.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new AvaliacaoMap());
            modelBuilder.ApplyConfiguration(new ModalidadeMap());
            modelBuilder.ApplyConfiguration(new PagamentoMap());
        }
    }
}
