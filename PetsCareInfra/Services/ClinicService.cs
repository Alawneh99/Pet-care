using PetsCareCore.DTOs.Clinic;
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
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepos _clinicRepository;

        public ClinicService(IClinicRepos clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public async Task<ClinicDTO> AddClinic(ClinicDTO createClinicDTO)
        {
            var clinic = new Clinic
            {
                Name = createClinicDTO.Name,
                Bio = createClinicDTO.Bio,
                Image = createClinicDTO.Image,
                Email = createClinicDTO.Email,
                Phone = createClinicDTO.Phone,
                UserID = createClinicDTO.UserID
            };

            var createdClinic = await _clinicRepository.AddClinic(clinic);

            return new ClinicDTO
            {
                Name = createdClinic.Name,
                Bio = createdClinic.Bio,
                Image = createdClinic.Image,
                Email = createdClinic.Email,
                Phone = createdClinic.Phone,
                UserID = createdClinic.UserID
            };
        }

        public async Task DeleteClinic(int clinicId)
        {
            await _clinicRepository.DeleteClinic(clinicId);
        }

        public async Task<UpdateClinicDTO> GetClinic(int clinicId)
        {
            var clinic = await _clinicRepository.GetClinicById(clinicId);
            if (clinic == null) return null;

            return new UpdateClinicDTO
            {
                Id = clinic.Id,
                Name = clinic.Name,
                Bio = clinic.Bio,
                Image = clinic.Image,
                Email = clinic.Email,
                Phone = clinic.Phone,
                UserID = clinic.UserID
            };
        }

        public async Task UpdateClinic(UpdateClinicDTO updateClinicDTO)
        {
            var clinic = await _clinicRepository.GetClinicById(updateClinicDTO.Id);
            if (clinic == null)
            {
                throw new Exception("Clinic not found");
            }

            clinic.Name = updateClinicDTO.Name;
            clinic.Bio = updateClinicDTO.Bio;
            clinic.Image = updateClinicDTO.Image;
            clinic.Email = updateClinicDTO.Email;
            clinic.Phone = updateClinicDTO.Phone;
            clinic.UserID = updateClinicDTO.UserID;

            await _clinicRepository.UpdateClinic(clinic);
        }
    }
}
