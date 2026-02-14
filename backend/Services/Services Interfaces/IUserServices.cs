using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services_Interfaces
{
    public interface IUserServices
    {
        Task<List<UserResponseDTO>> GetAllUsers();
        Task<UserResponseDTO?> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(CreateUserDTO dto);
       // Task UpdateStatusAsync(Guid id, UpdateTaskStatusDTO dto);
        Task DeleteAsync(Guid id);
    }
}
