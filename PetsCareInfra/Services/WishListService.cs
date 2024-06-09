using PetsCareCore.DTOs.WishList;
using PetsCareCore.Models.Entities;
using PetsCareCore.Repos;
using PetsCareCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareInfra.Services
{
    public class WishListService : IWishListService
    {
        private readonly IWishListRepos _wishListRepository;

        public WishListService(IWishListRepos wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }
        public async Task<WishListDTO> AddToWishList(WishListDTO createWishListDTO)
        {
            var wishList = new WishList
            {
                ItemName = createWishListDTO.ItemName,
                ItemImage = createWishListDTO.ItemImage
            };

            var createdWishList = await _wishListRepository.AddToWishList(wishList);

            return new WishListDTO
            {
                ItemName = createdWishList.ItemName,
                ItemImage = createdWishList.ItemImage
            };
        }

        public async Task<UpdateWishListDTO> GetWishList(int wishlistId)
        {
            var wishList = await _wishListRepository.GetWishList(wishlistId);
            if (wishList == null) return null;

            return new UpdateWishListDTO
            {
                Id = wishList.Id,
                ItemName = wishList.ItemName,
                ItemImage = wishList.ItemImage
            };
        }

        public async Task RemoveFromWishList(int wishListId)
        {
            await _wishListRepository.RemoveFromWishList(wishListId);
        }

        public async Task UpdateWishList(UpdateWishListDTO updateWishListDTO)
        {


            var wishList = await _wishListRepository.GetWishList(updateWishListDTO.Id);
            if (wishList == null)
            {
                throw new Exception("WishList not found");
            }

            wishList.ItemName = updateWishListDTO.ItemName;
            wishList.ItemImage = updateWishListDTO.ItemImage;

            await _wishListRepository.UpdateWishList(wishList);
        }
        }
}
