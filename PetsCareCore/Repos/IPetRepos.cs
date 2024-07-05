using PetsCareCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Repos
{
    public interface IPetRepos
    {
        Task<Pet> AddPet(Pet pet);
        Task<Pet> GetPetById(int petId);
        Task UpdatePet(Pet pet);
        Task DeletePet(int petId);
        Task<IEnumerable<Pet>> GetAllPets();
    }
}
