using PetsCareCore.DTOs.ClinicAppointment;
using PetsCareCore.Models.Entities;
using PetsCareCore.Repos;
using PetsCareCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareInfra.Services
{
    public class ClinicAppointmentService : IClinicAppointmentService
    {
        private readonly IClinicAppointmentRepos _clinicAppointmentRepository;

        public ClinicAppointmentService(IClinicAppointmentRepos clinicAppointmentRepository)
        {
            _clinicAppointmentRepository = clinicAppointmentRepository;
        }

        public async Task<ClinicAppointmentDTO> ScheduleAppointment(ClinicAppointmentDTO createAppointmentDTO)
        {
            var appointment = new ClinicAppointment
            {
                Date = createAppointmentDTO.Date,
                Price = createAppointmentDTO.Price,
                IsPaid = createAppointmentDTO.IsPaid,
                IsConfirmed = createAppointmentDTO.IsConfirmed,
                PetId = createAppointmentDTO.PetId,
                ClinicId = createAppointmentDTO.ClinicId
            };

            var createdAppointment = await _clinicAppointmentRepository.ScheduleAppointment(appointment);

            return new ClinicAppointmentDTO
            {
                Date = createdAppointment.Date,
                Price = createdAppointment.Price,
                IsPaid = createdAppointment.IsPaid,
                IsConfirmed = createdAppointment.IsConfirmed,
                PetId = createdAppointment.PetId,
                ClinicId = createdAppointment.ClinicId
            };
        }
        public async Task<UpdateClinicAppointmentDTO> GetAppointment(int appointmentId)
        {
            var appointment = await _clinicAppointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null) return null;

            return new UpdateClinicAppointmentDTO
            {
                Id = appointment.Id,
                Date = appointment.Date,
                Price = appointment.Price,
                IsPaid = appointment.IsPaid,
                IsConfirmed = appointment.IsConfirmed,
                PetId = appointment.PetId,
                ClinicId = appointment.ClinicId
            };
        }
        public async Task CancelAppointment(int appointmentId)
        {
            await _clinicAppointmentRepository.CancelAppointment(appointmentId);
        }
        public async Task UpdateAppointment(UpdateClinicAppointmentDTO updateAppointmentDTO)
        {
            var appointment = await _clinicAppointmentRepository.GetAppointmentById(updateAppointmentDTO.Id);
            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }

            appointment.Date = updateAppointmentDTO.Date;
            appointment.Price = updateAppointmentDTO.Price;
            appointment.IsPaid = updateAppointmentDTO.IsPaid;
            appointment.IsConfirmed = updateAppointmentDTO.IsConfirmed;
            appointment.PetId = updateAppointmentDTO.PetId;
            appointment.ClinicId = updateAppointmentDTO.ClinicId;

            await _clinicAppointmentRepository.UpdateAppointment(appointment);
        }
    }
}
