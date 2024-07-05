using PetsCareCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Repos
{
    public interface ICategoryRepos
    {
        Task<Category> AddCategory(Category category);
        Task<Category> GetCategoryById(int categoryId);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int categoryId);
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
