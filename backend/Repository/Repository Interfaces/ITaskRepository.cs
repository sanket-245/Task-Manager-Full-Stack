using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAENT = DataAccess.Entities;

namespace Repository.Repository_Interfaces
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <returns></returns>
        Task<List<DAENT.Task>> GetAllTasks();

        /// <summary>
        /// Get the Task by ID
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns></returns>
        Task<DAENT.Task?> GetTaskByID(Guid taskID);
        /// <summary>
        /// Adding the Task 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task AddTaskAsync(DAENT.Task task);

        /// <summary>
        /// Delete Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task DeleteTaskAsync(DAENT.Task task);

        /// <summary>
        /// Update the Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task UpdateTaskAsync(DAENT.Task task);
    }
}
