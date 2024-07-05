using PetsCareCore.DTOs.Service;
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
    public class ServiceService : IServicesService
    {
        private readonly IServiceRepos _serviceRepository;

        public ServiceService(IServiceRepos serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<ServiceDTO> AddService(ServiceDTO createServiceDTO)
        {
            var service = new Service
            {
                Name = createServiceDTO.Name,
                Description = createServiceDTO.Description,
                Price = createServiceDTO.Price,
                Duration = createServiceDTO.Duration,
                Image = createServiceDTO.Image
            };

            var createdService = await _serviceRepository.AddService(service);

            return new ServiceDTO
            {  
                Name = createdService.Name,
                Description = createdService.Description,
                Price = createdService.Price,
                Duration = createdService.Duration,
                Image = createdService.Image
            };
        }

        public async Task DeleteService(int serviceId)
        {
            await _serviceRepository.DeleteService(serviceId);
        }

        public async Task<IEnumerable<UpdateServiceDTO>> GetAllServices()
        {
            var services = await _serviceRepository.GetAllServices();
            return services.Select(service => new UpdateServiceDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                Duration = service.Duration,
                Image = service.Image
            });
        }

        public async Task<UpdateServiceDTO> GetService(int serviceId)
        {
            var service = await _serviceRepository.GetServiceById(serviceId);
            if (service == null) return null;

            return new UpdateServiceDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                Duration = service.Duration,
                Image = service.Image
            };
        }

        public async Task UpdateService(UpdateServiceDTO updateServiceDTO)
        {
            var service = await _serviceRepository.GetServiceById(updateServiceDTO.Id);
            if (service == null)
            {
                throw new Exception("Service not found");
            }

            service.Name = updateServiceDTO.Name;
            service.Description = updateServiceDTO.Description;
            service.Price = updateServiceDTO.Price;
            service.Duration = updateServiceDTO.Duration;
            service.Image = updateServiceDTO.Image;

            await _serviceRepository.UpdateService(service);
        }
    }
}
