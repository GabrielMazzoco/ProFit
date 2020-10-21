using System.Collections.Generic;
using IronFit.Domain.Shared.Entities;

namespace IronFit.Domain.Shared.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T Create(T obj);
        T Update(T obj);
        void Delete(int id);
        T GetById(int id);
        IList<T> GetAll();
        void Inactivate(T entity);
    }
}
