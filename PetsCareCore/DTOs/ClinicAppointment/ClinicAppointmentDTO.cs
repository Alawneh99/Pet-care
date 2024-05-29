using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.DTOs.ClinicAppointment
{
    public class ClinicAppointmentDTO
    {
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public bool IsPaid { get; set; }
        public bool IsConfirmed { get; set; }
        public int? PetId { get; set; }
        public int? ClinicId { get; set; }
    }
}
