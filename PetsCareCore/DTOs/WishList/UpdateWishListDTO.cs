using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.DTOs.WishList
{
    public class UpdateWishListDTO
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
    }
}
