using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAENT = DataAccess.Entities;

namespace Repository.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerDbContext _dbContext;
        public TaskRepository(TaskManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <returns></returns>
        public async Task<List<DAENT.Task>> GetAllTasks()
        {
            var tasks = new List<DAENT.Task>();

            tasks = await _dbContext.Tasks.ToListAsync();

            return tasks;
        }

        /// <summary>
        /// Get the Task by the ID
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns></returns>
        public async Task<DAENT.Task?> GetTaskByID(Guid taskID)
        {
            var task = new DAENT.Task();

            task = await _dbContext.Tasks.Where(x => x.TaskId == taskID).FirstOrDefaultAsync();

            return task;
        }

        /// <summary>
        /// Add the Task 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task AddTaskAsync(DAENT.Task task)
        {
            if (task != null)
            {
                _dbContext.Tasks.Add(task);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete the Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task DeleteTaskAsync(DAENT.Task task)
        {
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Update the Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task UpdateTaskAsync(DAENT.Task task)
        {
            if (task != null)
            {
                _dbContext.Tasks.Update(task);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}