﻿using System.Linq;
using IronFit.Domain.AuthAggregate.Dtos;
using IronFit.Domain.AuthAggregate.Entities;
using IronFit.Domain.AuthAggregate.Repositories;
using IronFit.Domain.Shared.Filters;

namespace IronFit.Adapter.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public User GetByUsername(string userName)
        {
           var user = DbContext.Set<User>().FirstOrDefault(x => x.UserName == userName);

           return user;
        }

        public GenericFilter<UsersForList> GetUsers(GenericFilter<UsersForList> filter)
        {
            var query = DbContext.Set<User>().Where(x => !x.Admin && x.Active);

            if (filter.ItemsPerPage != 0 && filter.Page != 0)
            {
                query = query.Skip((filter.Page - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);
            }

            query = query.OrderBy(x => x.Name);

            filter.Items = query.Select(x => new UsersForList
            {
                Name = x.Name,
                Username = x.UserName
            }).ToList();

            return filter;
        }
    }
}
