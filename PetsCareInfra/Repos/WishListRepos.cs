using PetsCareCore.Context;
using PetsCareCore.Models.Entities;
using PetsCareCore.Repos;
using PetsCareCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareInfra.Repos
{
    public class WishListRepos : IWishListRepos
    {

        private readonly PetCareDbcontext _context;

        public WishListRepos(PetCareDbcontext context)
        {
            _context = context;
        }

        public async Task<WishList> AddToWishList(WishList wishList)
        {
            _context.WishLists.Add(wishList);
            await _context.SaveChangesAsync();
            return wishList;
        }

        public async Task<WishList> GetWishList(int wishListId)
        {
            return await _context.WishLists.FindAsync(wishListId);
        }

        public async Task RemoveFromWishList(int wishListId)
        {
            var wishList = await _context.WishLists.FindAsync(wishListId);
            if (wishList != null)
            {
                _context.WishLists.Remove(wishList);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateWishList(WishList wishList)
        {
            _context.WishLists.Update(wishList);
            await _context.SaveChangesAsync();
        }
    }
}
