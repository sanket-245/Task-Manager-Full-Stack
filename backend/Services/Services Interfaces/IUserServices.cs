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
       //Task<List<UserResponseDTO>> GetAllUsers();
        Task<UserResponseDTO?> GetUserByEmailAsync(String emailid);
        Task CreateUserAsync(CreateUserDTO dto);

        Task<Boolean> GetAuthenticate(String username, String password);
       // Task UpdateStatusAsync(Guid id, UpdateTaskStatusDTO dto);
       // Task DeleteAsync(Guid id);
    }
}
