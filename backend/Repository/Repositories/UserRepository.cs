using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DAENT = DataAccess.Entities;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagerDbContext _dbContext;
        public UserRepository(TaskManagerDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        public async Task<List<DAENT.User>> GetAllUsers()
        {
            var users = new List<DAENT.User>();

            users = await _dbContext.Users.ToListAsync();

            return users;
        }

        /// <summary>
        /// Get the User by the ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DAENT.User?> GetUserByEmailID(string Email)
        {
            var User = new DAENT.User();

            User = await _dbContext.Users.Where(x => x.EmailId == Email).FirstOrDefaultAsync();

            return User;
        }

        /// <summary>
        /// Add the User 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddUserAsync(DAENT.User user)
        {
            if (user != null)
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete the User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task DeleteUserAsync(DAENT.User user)
        {
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Update the User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task UpdateUserAsync(DAENT.User user)
        {
            if (user != null)
            {
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
