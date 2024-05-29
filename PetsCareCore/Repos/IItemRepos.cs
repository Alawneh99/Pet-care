using PetsCareCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Repos
{
    public interface IItemRepos
    {
        Task<Item> AddItem(Item item);
        Task<Item> GetItemById(int itemId);
        Task UpdateItem(Item item);
        Task DeleteItem(int itemId);
    }
}
