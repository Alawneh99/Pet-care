using PetsCareCore.DTOs.User;
using PetsCareCore.DTOs.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Services
{
    public interface IUserService
    {
        Task<CreateUserDTO> CreateUser(CreateUserDTO createUserDTO);
        Task<UpdateUserDTO> GetUser(int userId);
        Task UpdateUser(UpdateUserDTO updateUserDTO);
        Task DeleteUser(int userId);
    }
}
