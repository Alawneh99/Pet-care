using PetsCareCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Repos
{
    public interface IWishListRepos
    {
        Task<WishList> AddToWishList(WishList wishList);
        Task<IEnumerable<WishList>> GetWishListByUserId(int userId);
        Task UpdateWishList(WishList wishList);
        Task RemoveFromWishList(int wishListId);
    }
}
