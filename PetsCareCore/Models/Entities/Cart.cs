using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int? UserId { get; set; }   
    }
}
