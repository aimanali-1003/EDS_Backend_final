using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class CategoryDAL
    {
        private readonly DBContext _dbContext;

        public CategoryDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            // Implement logic to retrieve a category by ID from your database
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            // Implement logic to retrieve all categories from your database
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            category.CreatedAt = DateTime.Now;
            category.CreatedBy = "Zamaan";
            // Implement logic to create a new category in your database
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            // Implement logic to update a category in your database
            var existingCategory = await _dbContext.Categories.FindAsync(id);
            if (existingCategory == null)
                return null; // Category not found

            // Update the properties of the existing category with the new data
            existingCategory.CategoryCode = category.CategoryCode;
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingCategory.UpdatedBy = category.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            // Implement logic to delete a category from your database
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
                return false; // Category not found

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }
    }
}
