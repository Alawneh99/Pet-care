using PetsCareCore.DTOs.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Services
{
    public interface IPetService
    {
        Task<CreatePetDTO> AddPet(CreatePetDTO createPetDTO);
        Task<UpdatePetDTO> GetPet(int petId);
        Task UpdatePet(UpdatePetDTO updatePetDTO);
        Task DeletePet(int petId);
        Task<IEnumerable<UpdatePetDTO>> GetAllPets();
    }
}
