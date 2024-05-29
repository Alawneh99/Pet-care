using PetsCareCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Repos
{
    public interface IServiceRepos
    {
        Task<Service> AddService(Service service);
        Task<Service> GetServiceById(int serviceId);
        Task UpdateService(Service service);
        Task DeleteService(int serviceId);
    }
}
