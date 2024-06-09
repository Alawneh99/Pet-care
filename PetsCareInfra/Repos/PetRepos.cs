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
    public class PetRepos : IPetRepos
    {
        private readonly PetCareDbcontext _context;

        public PetRepos(PetCareDbcontext context)
        {
            _context = context;
        }
        public async Task<Pet> AddPet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task DeletePet(int petId)
        {
            var pet = await GetPetById(petId);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Pet> GetPetById(int petId)
        {
            return await _context.Pets.FindAsync(petId);
        }

        public async Task UpdatePet(Pet pet)
        {
            _context.Pets.Update(pet);
            await _context.SaveChangesAsync();
        }
    }
}
