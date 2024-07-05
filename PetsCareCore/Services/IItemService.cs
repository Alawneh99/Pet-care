using PetsCareCore.DTOs.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Services
{
    public interface IItemService
    {
        Task<ItemDTO> AddItem(ItemDTO createItemDTO);
        Task<UpdateItemDTO> GetItem(int itemId);
        Task UpdateItem(UpdateItemDTO updateItemDTO);
        Task DeleteItem(int itemId);
        Task<IEnumerable<UpdateItemDTO>> GetAllItems();
    }
}
