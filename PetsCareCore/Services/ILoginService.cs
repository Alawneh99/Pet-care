using PetsCareCore.DTOs.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Services
{
    public interface ILoginService
    {
        Task<string> SignIn(LoginDTO loginDTO);
        Task<bool> SignOut(int userId);
        Task<bool> RecoverPassword(RecoverPasswordDTO recoverPasswordDTO);
        Task<bool> ResetPassword(string email, string token, string newPassword);

    }
}
