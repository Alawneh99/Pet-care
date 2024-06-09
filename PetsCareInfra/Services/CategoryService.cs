using PetsCareCore.DTOs.Category;
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
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepos _categoryRepository;

        public CategoryService(ICategoryRepos categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryDTO> AddCategory(CategoryDTO createCategoryDTO)
        {
            var category = new Category
            {
                Name = createCategoryDTO.Name,
                Image = createCategoryDTO.Image
            };

            var createdCategory = await _categoryRepository.AddCategory(category);

            return new CategoryDTO
            {
                Name = createdCategory.Name,
                Image = createdCategory.Image
            };
        }

        public async Task DeleteCategory(int categoryId)
        {
            await _categoryRepository.DeleteCategory(categoryId);
        }

        public async Task<UpdateCategoryDTO> GetCategory(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);
            if (category == null) return null;

            return new UpdateCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image
            };
        }

        public async Task UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var category = await _categoryRepository.GetCategoryById(updateCategoryDTO.Id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }

            category.Name = updateCategoryDTO.Name;
            category.Image = updateCategoryDTO.Image;

            await _categoryRepository.UpdateCategory(category);
        }
    }
}
