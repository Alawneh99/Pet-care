using PetsCareCore.DTOs.ClinicAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Services
{
    public interface IClinicAppointmentService
    {
        Task<ClinicAppointmentDTO> ScheduleAppointment(ClinicAppointmentDTO createAppointmentDTO);
        Task<UpdateClinicAppointmentDTO> GetAppointment(int appointmentId);
        Task UpdateAppointment(UpdateClinicAppointmentDTO updateAppointmentDTO);
        Task CancelAppointment(int appointmentId);
    }
}
