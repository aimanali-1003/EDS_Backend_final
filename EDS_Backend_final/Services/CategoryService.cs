using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryDAL _categoryDAL;

        public CategoryService(CategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _categoryDAL.GetCategoryAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryDAL.GetAllCategoriesAsync();
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            return await _categoryDAL.CreateCategoryAsync(category);
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
       return await _categoryDAL.UpdateCategoryAsync(id, category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _categoryDAL.DeleteCategoryAsync(id);
        }

        //public async Task<IEnumerable<Columns>> GetCategoryColumnsAsync(int categoryId)
        //{
        //    // Implement logic to call the CategoryDAL's GetCategoryColumnsAsync method
        //    return await _categoryDAL.GetCategoryColumnsAsync(categoryId);
        //}

        //public async Task<IEnumerable<Category>> GetCategoriesWithColumnsAsync()
        //{
        //    return await _categoryDAL.GetCategoriesWithColumnsAsync();
        //}
    }
}
