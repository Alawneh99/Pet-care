using Microsoft.EntityFrameworkCore;
using PetsCareCore.Context;
using PetsCareCore.Models.Entities;
using PetsCareCore.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareInfra.Repos
{
    public class ClinicAppointmentRepos : IClinicAppointmentRepos
    {
        private readonly PetCareDbcontext _context;

        public ClinicAppointmentRepos(PetCareDbcontext context)
        {
            _context = context;
        }
        public async Task CancelAppointment(int appointmentId)
        {
            var appointment = await GetAppointmentById(appointmentId);
            if (appointment != null)
            {
                _context.ClinicsAppointment.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ClinicAppointment>> GetAllAppointments()
        {
            return await _context.ClinicsAppointment.ToListAsync();
        }

        public async Task<ClinicAppointment> GetAppointmentById(int appointmentId)
        {
            return await _context.ClinicsAppointment.FindAsync(appointmentId);
        }

        public async Task<ClinicAppointment> ScheduleAppointment(ClinicAppointment appointment)
        {
            _context.ClinicsAppointment.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task UpdateAppointment(ClinicAppointment appointment)
        {
            _context.ClinicsAppointment.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
