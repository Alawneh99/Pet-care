using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Models.Entities
{
    public class ClinicAppointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public bool IsPaid { get; set; }
        public bool IsConfirmed { get; set; }
        public int? PetId { get; set; }
        public int? ClinicId { get; set; }
    }
}
