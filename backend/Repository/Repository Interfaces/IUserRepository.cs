using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAENT = DataAccess.Entities;

namespace Repository.Repository_Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        Task<List<DAENT.User>> GetAllUsers();

        /// <summary>
        /// Get the User by ID
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns></returns>
        Task<DAENT.User?> GetUserByID(Guid taskId);
        /// <summary>
        /// Adding the User 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task AddUserAsync(DAENT.User task);

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task DeleteUserAsync(DAENT.User task);

        /// <summary>
        /// Update the User
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task UpdateUserAsync(DAENT.User task);
    }
}
