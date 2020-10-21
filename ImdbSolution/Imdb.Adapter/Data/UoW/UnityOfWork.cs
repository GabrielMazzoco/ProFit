using System.Linq;
using IronFit.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IronFit.Adapter.Data.UoW
{
    public class UnityOfWork : IUnityOfWork
    {
        protected readonly DataContext DbContext;
        public UnityOfWork(DataContext dbContext)
        {
            DbContext = dbContext;
        }
        public bool Commit()
        {
            if (DbContext.ChangeTracker.Entries().Any(e =>
                e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
            {
                return DbContext.SaveChanges() > 0;
            }
            return false;
        }
    }
}
