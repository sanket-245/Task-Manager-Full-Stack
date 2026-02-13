using Repository.Repository_Interfaces;
using Services.Services_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs;

namespace Services.Services
{
    public  class TaskServices : ITaskServices
    {
        private readonly ITaskRepository _taskRepository;
        public TaskServices(ITaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskResponseDTO>> GetAllAsync()
        {
            var response = new List<TaskResponseDTO>();
            var result = await _taskRepository.GetAllTasks();
            response = result.Select(
                T=> new TaskResponseDTO
                { 
                    TaskID = T.TaskId,
                    TaskName = T.TaskName,
                    TaskDescription = T.TaskDescription,
                    StatusId = T.TaskStatusId
                }
            ).ToList();
            return response;
        }
        public async Task<TaskResponseDTO?> GetByIdAsync(Guid id)
        {
            
            var result = await _taskRepository.GetTaskByID(id);

            if(result== null)
                return null;

            var response = new TaskResponseDTO
            {
                TaskID = result.TaskId,
                TaskName = result.TaskName,
                TaskDescription = result.TaskDescription,
                StatusId = result.TaskStatusId
            };

            return response;
        }
        public async Task CreateAsync(CreateTaskDTO dto)
        {
            var request = new DataAccess.Entities.Task
            {
                TaskName = dto.TaskName,
                TaskDescription = dto.TaskDescripion,
                UserId = dto.UserID,
                TaskStatusId = DataAccess.Enums.TaskStatusEnum.NotStarted,
                CreatedAt = DateTime.Now,
                DueDate = dto.TaskDuedate
            };

            await _taskRepository.AddTaskAsync(request);
        }
       public async Task UpdateStatusAsync(Guid id, UpdateTaskStatusDTO dto)
        {
            var task = await _taskRepository.GetTaskByID(id);

            if (task == null)
                throw new Exception("Task not found");

            task.TaskStatusId = dto.TaskStatusId;

            await _taskRepository.UpdateTaskAsync(task);
        }
        public async Task DeleteAsync(Guid id)
        {
            var request = await _taskRepository.GetTaskByID(id);
            if (request == null)
                throw new Exception("Task Not Found");

            await _taskRepository.DeleteTaskAsync(request);
        }

    }
}
