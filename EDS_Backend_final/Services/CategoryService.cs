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
    }
}
