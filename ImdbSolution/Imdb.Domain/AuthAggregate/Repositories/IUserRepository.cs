using IronFit.Domain.AuthAggregate.Dtos;
using IronFit.Domain.AuthAggregate.Entities;
using IronFit.Domain.Shared.Filters;
using IronFit.Domain.Shared.Interfaces;

namespace IronFit.Domain.AuthAggregate.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string userName);
        GenericFilter<UsersForList> GetUsers(GenericFilter<UsersForList> filter);
    }
}
