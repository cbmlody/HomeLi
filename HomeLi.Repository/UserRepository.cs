using HomeLi.Contracts.Repositories;
using HomeLi.Entities;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeLi.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(user => user.LastName);
        }

        public User GetUserById(Guid id)
        {
            return FindByCondition(user => user.Id.Equals(id))
                .DefaultIfEmpty(new User())
                .FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            CreateUser(user);
            Save();
        }
        
        public void UpdateUser(User dbUser, User user)
        {
            dbUser.Map(user);
            Update(dbUser);
            Save();
        }

        public void DeleteUser(User user)
        {
            Delete(user);
            Save();
        }
    }
}