using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Models.Entities
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; } 
        public string Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
