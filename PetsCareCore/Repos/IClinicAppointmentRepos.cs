using PetsCareCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Repos
{
    public interface IClinicAppointmentRepos
    {
        Task<ClinicAppointment> ScheduleAppointment(ClinicAppointment appointment);
        Task<ClinicAppointment> GetAppointmentById(int appointmentId);
        Task UpdateAppointment(ClinicAppointment appointment);
        Task CancelAppointment(int appointmentId);
        Task<IEnumerable<ClinicAppointment>> GetAllAppointments();
    }
}
