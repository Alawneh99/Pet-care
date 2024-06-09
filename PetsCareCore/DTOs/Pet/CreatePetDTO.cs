using PetsCareCore.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.DTOs.Pet
{
    public class CreatePetDTO
    {
        public string NickName { get; set; }
        public Enums.Gender Gender { get; set; }
        public Enums.PetType PetType { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public DateOnly BirthDate { get; set; }
        public int? OwnerUserId { get; set; }
    }
}
