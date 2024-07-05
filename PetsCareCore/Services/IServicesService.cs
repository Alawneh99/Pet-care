using PetsCareCore.DTOs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Services
{
    public interface IServicesService
    {
        Task<ServiceDTO> AddService(ServiceDTO createServiceDTO);
        Task<UpdateServiceDTO> GetService(int serviceId);
        Task UpdateService(UpdateServiceDTO updateServiceDTO);
        Task DeleteService(int serviceId);
        Task<IEnumerable<UpdateServiceDTO>> GetAllServices();
    }
}
