using Repository.Repository_Interfaces;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    class UserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

      
        public async Task<UserResponseDTO?> GetUserByEmailAsync(string emailid)
        {

            var result = await _userRepository.GetUserByEmailID(emailid);

            if (result == null)
                return null;

            var response = new UserResponseDTO
            {
                UserName = result.FullName,
                Email = result.EmailId,
                Password = result.PasswordHash,
            };

            return response;
        }

        public async Task CreateUserAsync(CreateUserDTO dto)
        {
            if (dto != null)
            {
                var request = new DataAccess.Entities.User
                {
                    FullName = dto.UserName,
                    EmailId = dto.Email,
                    PasswordHash = dto.Password,
                    CreatedAt = dto.CreatedAt,
                };
                await _userRepository.AddUserAsync(request);
            }

            return;
        }
    }
}
