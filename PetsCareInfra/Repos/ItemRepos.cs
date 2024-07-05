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
    public class ItemRepos : IItemRepos
    {
        private readonly PetCareDbcontext _context;

        public ItemRepos(PetCareDbcontext context)
        {
            _context = context;
        }
        public async Task<Item> AddItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItem(int itemId)
        {
            var item = await GetItemById(itemId);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemById(int itemId)
        {
            return await _context.Items.FindAsync(itemId);
        }

        public async Task UpdateItem(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
