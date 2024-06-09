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
    public class ClinicRepos : IClinicRepos
    {
        private readonly PetCareDbcontext _context;

        public ClinicRepos(PetCareDbcontext context)
        {
            _context = context;
        }
        public async Task<Clinic> AddClinic(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            await _context.SaveChangesAsync();
            return clinic;
        }

        public async Task DeleteClinic(int clinicId)
        {
            var clinic = await GetClinicById(clinicId);
            if (clinic != null)
            {
                _context.Clinics.Remove(clinic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Clinic> GetClinicById(int clinicId)
        {
            return await _context.Clinics.FindAsync(clinicId);
        }

        public async Task UpdateClinic(Clinic clinic)
        {
            _context.Clinics.Update(clinic);
            await _context.SaveChangesAsync();
        }
    }
}
