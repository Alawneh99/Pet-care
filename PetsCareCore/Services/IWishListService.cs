﻿using PetsCareCore.DTOs.WishList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Services
{
    public interface IWishListService
    {
        Task<WishListDTO> AddToWishList(WishListDTO createWishListDTO);
        Task<IEnumerable<UpdateWishListDTO>> GetWishList(int userId);
        Task UpdateWishList(UpdateWishListDTO updateWishListDTO);
        Task RemoveFromWishList(int wishListId);
    }
}