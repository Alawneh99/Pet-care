using PetsCareCore.DTOs.Item;
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
    public class ItemService : IItemService
    {
        private readonly IItemRepos _itemRepository;

        public ItemService(IItemRepos itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<ItemDTO> AddItem(ItemDTO createItemDTO)
        {
            var item = new Item
            {
                Name = createItemDTO.Name,
                Description = createItemDTO.Description,
                Image = createItemDTO.Image,
                Price = createItemDTO.Price,
                Quantity = createItemDTO.Quantity,
                IsHaveDiscount = createItemDTO.IsHaveDiscount,
                DiscountAmount = createItemDTO.DiscountAmount,
                DiscountType = createItemDTO.DiscountType,
                CategoryID = createItemDTO.CategoryID,
                OrderId = createItemDTO.OrderId
            };

            var createdItem = await _itemRepository.AddItem(item);

            return new ItemDTO
            {
                
                Name = createdItem.Name,
                Description = createdItem.Description,
                Image = createdItem.Image,
                Price = createdItem.Price,
                Quantity = createdItem.Quantity,
                IsHaveDiscount = createdItem.IsHaveDiscount,
                DiscountAmount = createdItem.DiscountAmount,
                DiscountType = createdItem.DiscountType,
                CategoryID = createdItem.CategoryID,
                OrderId = createdItem.OrderId
            };
        }

        public Task DeleteItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UpdateItemDTO>> GetAllItems()
        {
            var items = await _itemRepository.GetAllItems();
            return items.Select(item => new UpdateItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Image = item.Image,
                Price = item.Price,
                Quantity = item.Quantity,
                IsHaveDiscount = item.IsHaveDiscount,
                DiscountAmount = item.DiscountAmount,
                DiscountType = item.DiscountType,
                CategoryID = item.CategoryID,
                OrderId = item.OrderId
            });
        }

        public async Task<UpdateItemDTO> GetItem(int itemId)
        {
            var item = await _itemRepository.GetItemById(itemId);
            if (item == null) return null;

            return new UpdateItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Image = item.Image,
                Price = item.Price,
                Quantity = item.Quantity,
                IsHaveDiscount = item.IsHaveDiscount,
                DiscountAmount = item.DiscountAmount,
                DiscountType = item.DiscountType,
                CategoryID = item.CategoryID,
                OrderId = item.OrderId
            };
        }

        public async Task UpdateItem(UpdateItemDTO updateItemDTO)
        {
            var item = await _itemRepository.GetItemById(updateItemDTO.Id);
            if (item == null)
            {
                throw new Exception("Item not found");
            }

            item.Name = updateItemDTO.Name;
            item.Description = updateItemDTO.Description;
            item.Image = updateItemDTO.Image;
            item.Price = updateItemDTO.Price;
            item.Quantity = updateItemDTO.Quantity;
            item.IsHaveDiscount = updateItemDTO.IsHaveDiscount;
            item.DiscountAmount = updateItemDTO.DiscountAmount;
            item.DiscountType = updateItemDTO.DiscountType;
            item.CategoryID = updateItemDTO.CategoryID;
            item.OrderId = updateItemDTO.OrderId;

            await _itemRepository.UpdateItem(item);
        }
    }
}
