using PetsCareCore.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> AddCategory(CategoryDTO createCategoryDTO);
        Task<UpdateCategoryDTO> GetCategory(int categoryId);
        Task UpdateCategory(UpdateCategoryDTO updateCategoryDTO);
        Task DeleteCategory(int categoryId);
        Task<IEnumerable<UpdateCategoryDTO>> GetAllCategories();
    }
}
