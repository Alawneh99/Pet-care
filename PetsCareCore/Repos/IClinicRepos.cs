using PetsCareCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Repos
{
    public interface IClinicRepos
    {
        Task<Clinic> AddClinic(Clinic clinic);
        Task<Clinic> GetClinicById(int clinicId);
        Task UpdateClinic(Clinic clinic);
        Task DeleteClinic(int clinicId);
    }
}
