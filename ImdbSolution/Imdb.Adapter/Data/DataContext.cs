using IronFit.Adapter.Data.Mappings;
using IronFit.Domain.AuthAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

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

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Active = true,
                Admin = true,
                Name = "Gabriel Mazzoco",
                UserName = "mazzoco",
                PasswordHash = BC.HashPassword("mazzoco"),
                Academias = "1,2"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Active = true,
                Admin = true,
                Name = "Brenner Mazzoco",
                UserName = "brenner",
                PasswordHash = BC.HashPassword("mazzoco"),
                Academias = "1,2"
            });
        }
    }
}
