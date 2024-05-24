using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Models.Entities
{
    public class Pet {
        public int Id { get; set; } 
        public string NickName { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public int? OwnerUserId { get; set; }
    }
}
