using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.DTOs.Clinic
{
    public class ClinicDTO
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? UserID { get; set; }
    }
}
