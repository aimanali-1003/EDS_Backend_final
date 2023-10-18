using EDS_Backend_final.DataContext;
using EDS_Backend_final.Exceptions;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class CategoryDAL
    {
        private readonly DBContext _dbContext;

        public CategoryDAL(DBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            var isCategoryCodeUnique = await IsCategoryCodeUniqueAsync(category.CategoryCode, 0); // 0 means it's a new entry
            var isCategoryNameUnique = await IsCategoryNameUniqueAsync(category.CategoryName, 0);

            if (!isCategoryCodeUnique || !isCategoryNameUnique)
            {
                // Category code or name is not unique, throw a custom exception
                throw new ValidationException("Category code or name is already exists");
            }

            if (!IsValidAlphanumeric(category.CategoryCode) || !IsValidAlphanumeric(category.CategoryName))
            {
                // Category code or name contains invalid characters, throw a custom exception
                throw new ValidationException("Category code or name contains invalid characters");
            }

            category.CreatedAt = DateTime.Now;
            category.CreatedBy = "Zamaan";
            category.Active = true;


            // Implement logic to create a new category in your database
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }


        public async Task<Category> UpdateCategoryAsync(int id, Category category)
{
    // Check if the category with the given ID exists
            var existingCategory = await _dbContext.Categories.FindAsync(id);
            if (existingCategory == null)
                return null; // Category not found

            // Check if the updated category code and name are unique
            var isCategoryCodeUnique = await IsCategoryCodeUniqueAsync(category.CategoryCode, id);
            var isCategoryNameUnique = await IsCategoryNameUniqueAsync(category.CategoryName, id);

            if (existingCategory == null)
            {
                // Category not found, throw a custom exception
                throw new ValidationException("Category not found");
            }

            // Check for other custom validation, e.g., uniqueness of category code or name
            if (!isCategoryCodeUnique ||!isCategoryNameUnique)
            {
                // Category code is not unique, throw a custom exception
                throw new ValidationException("Category code or name is already exists!");
            }

            if (!IsValidAlphanumeric(category.CategoryCode) || !IsValidAlphanumeric(category.CategoryName))
            {
                throw new ValidationException("Category code or name contains invalid characters");
            }

            if (category.CategoryCode == existingCategory.CategoryCode && category.CategoryName == existingCategory.CategoryName && category.Active == existingCategory.Active)
            {
                throw new ValidationException("No changes were made");
            }

            existingCategory.CategoryCode = category.CategoryCode;
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Active = category.Active;
            existingCategory.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingCategory.UpdatedBy = "Zamaan";

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

        private async Task<bool> IsCategoryCodeUniqueAsync(string categoryCode, int categoryId)
        {
            return !await _dbContext.Categories.AnyAsync(c => c.CategoryCode == categoryCode && c.CategoryID != categoryId);
        }

        private async Task<bool> IsCategoryNameUniqueAsync(string categoryName, int categoryId)
        {
            return !await _dbContext.Categories.AnyAsync(c => c.CategoryName == categoryName && c.CategoryID != categoryId);
        }

        private bool IsValidAlphanumeric(string value)
        {
            var pattern = "^[a-zA-Z0-9 ]*$";
            return Regex.IsMatch(value, pattern);
        }


    }
}
