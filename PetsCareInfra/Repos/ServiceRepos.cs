using Microsoft.EntityFrameworkCore;
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
    public class ServiceRepos : IServiceRepos
    {
        private readonly PetCareDbcontext _context;

        public ServiceRepos(PetCareDbcontext context)
        {
            _context = context;
        }
        public async Task<Service> AddService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task DeleteService(int serviceId)
        {
            var service = await GetServiceById(serviceId);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetServiceById(int serviceId)
        {
            return await _context.Services.FindAsync(serviceId);
        }

        public async Task UpdateService(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }
    }
}
