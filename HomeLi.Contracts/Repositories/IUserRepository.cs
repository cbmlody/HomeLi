using HomeLi.Entities.Models;
using System;
using System.Collections.Generic;

namespace HomeLi.Contracts.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Gets user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        User GetUserById(Guid id);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void CreateUser(User user);

        /// <summary>
        /// Updates database user with new values.
        /// </summary>
        /// <param name="dbUser">The databse user.</param>
        /// <param name="user">The user.</param>
        void UpdateUser(User dbUser, User user);
        
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void DeleteUser(User user);
    }
}
