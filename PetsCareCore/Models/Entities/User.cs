using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Models.Entities
{
    public class User
    {
        public int Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ProfileImage { get; set; }
        public int UserRoleID { get; set; }
        public string ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordExpiry { get; set; }
        public string PasswordHash { get; set; }
    }
}
