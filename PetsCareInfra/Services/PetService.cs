using PetsCareCore.DTOs.Pet;
using PetsCareCore.Models.Entities;
using PetsCareCore.Repos;
using PetsCareCore.Services;
using PetsCareInfra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareInfra.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepos _petRepository;

        public PetService(IPetRepos petRepository)
        {
            _petRepository = petRepository;
        }
        public async Task<CreatePetDTO> AddPet(CreatePetDTO createPetDTO)
        {
            var pet = new Pet
            {
                NickName = createPetDTO.NickName,
                Gender = createPetDTO.Gender,
                PetType = createPetDTO.PetType,
                Image = createPetDTO.Image,
                Age = createPetDTO.Age,
                BirthDate = createPetDTO.BirthDate,
                OwnerUserId = createPetDTO.OwnerUserId
            };

            var createdPet = await _petRepository.AddPet(pet);

            return new CreatePetDTO
            {
                NickName = createdPet.NickName,
                Gender = createdPet.Gender,
                PetType = createdPet.PetType,
                Image = createdPet.Image,
                Age = createdPet.Age,
                BirthDate = createdPet.BirthDate,
                OwnerUserId = createdPet.OwnerUserId
            };
        }

        public async Task DeletePet(int petId)
        {
            await _petRepository.DeletePet(petId);
        }

        public async Task<IEnumerable<UpdatePetDTO>> GetAllPets()
        {
            var pets = await _petRepository.GetAllPets();
            return pets.Select(pet => new UpdatePetDTO
            {
                Id = pet.Id,
                NickName = pet.NickName,
                Gender = pet.Gender,
                PetType = pet.PetType,
                Image = pet.Image,
                Age = pet.Age,
                BirthDate = pet.BirthDate,
                OwnerUserId = pet.OwnerUserId
            });
        }

        public async Task<UpdatePetDTO> GetPet(int petId)
        {
            var pet = await _petRepository.GetPetById(petId);
            if (pet == null) return null;

            return new UpdatePetDTO
            {
                Id = pet.Id,
                NickName = pet.NickName,
                Gender = pet.Gender,
                PetType = pet.PetType,
                Image = pet.Image,
                Age = pet.Age,
                BirthDate = pet.BirthDate,
                OwnerUserId = pet.OwnerUserId
            };
        }

        public async Task UpdatePet(UpdatePetDTO updatePetDTO)
        {
            var pet = await _petRepository.GetPetById(updatePetDTO.Id);
            if (pet == null)
            {
                throw new Exception("Pet not found");
            }

            pet.NickName = updatePetDTO.NickName;
            pet.Gender = updatePetDTO.Gender;
            pet.PetType = updatePetDTO.PetType;
            pet.Image = updatePetDTO.Image;
            pet.Age = updatePetDTO.Age;
            pet.BirthDate = updatePetDTO.BirthDate;
            pet.OwnerUserId = updatePetDTO.OwnerUserId;

            await _petRepository.UpdatePet(pet);
        }
    }
}
