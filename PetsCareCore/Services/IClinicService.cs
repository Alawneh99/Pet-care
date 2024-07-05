using PetsCareCore.DTOs.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Services
{
    public interface IClinicService
    {
        Task<ClinicDTO> AddClinic(ClinicDTO createClinicDTO);
        Task<UpdateClinicDTO> GetClinic(int clinicId);
        Task UpdateClinic(UpdateClinicDTO updateClinicDTO);
        Task DeleteClinic(int clinicId);
        Task<IEnumerable<UpdateClinicDTO>> GetAllClinics();
    }
}
