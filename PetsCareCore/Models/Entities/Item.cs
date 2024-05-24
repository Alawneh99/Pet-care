using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Models.Entities
{
    public class Item
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public bool IsHaveDiscount { get; set; }
        public float DiscountAmount { get; set; }
        public string DiscountType { get; set; }
        public int? CategoryID { get; set; }
        public int? OrderId { get; set; }
    }
}
