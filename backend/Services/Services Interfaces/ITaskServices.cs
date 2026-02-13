using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs;

namespace Services.Services_Interfaces
{
    public interface ITaskServices
    {
        Task<List<TaskResponseDTO>> GetAllAsync();
        Task<TaskResponseDTO?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateTaskDTO dto);
        Task UpdateStatusAsync(Guid id, UpdateTaskStatusDTO dto);
        Task DeleteAsync(Guid id);
    }
}
