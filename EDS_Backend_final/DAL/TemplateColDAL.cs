using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class TemplateColDAL
    {
        private readonly DBContext _dbContext;

        public TemplateColDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<TemplateColumns> GetTemplateColAsync(int id)
        {
            // Implement logic to retrieve a template collection by ID from your database
            return await _dbContext.TemplateColumns.FindAsync(id);
        }

        public async Task<IEnumerable<TemplateColumns>> GetAllTemplateColsAsync()
        {
            // Implement logic to retrieve all template collections from your database
            return await _dbContext.TemplateColumns.ToListAsync();
        }

        public async Task<TemplateColumns> CreateTemplateColAsync(TemplateColumns templateCollection)
        {
            templateCollection.CreatedAt = DateTime.Now;
            templateCollection.CreatedBy = "YourUsername";
            // Implement logic to create a new template collection in your database
            _dbContext.TemplateColumns.Add(templateCollection);
            await _dbContext.SaveChangesAsync();
            return templateCollection;
        }

        public async Task<TemplateColumns> UpdateTemplateColAsync(int id, TemplateColumns templateCollection)
        {
            // Implement logic to update a template collection in your database
            var existingTemplateCollection = await _dbContext.TemplateColumns.FindAsync(id);
            if (existingTemplateCollection == null)
                return null; // Template collection not found

            // Update the properties of the existing template collection with the new data
        
            existingTemplateCollection.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingTemplateCollection.UpdatedBy = templateCollection.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingTemplateCollection;
        }

        public async Task<bool> DeleteTemplateColAsync(int id)
        {
            // Implement logic to delete a template collection from your database
            var templateCollection = await _dbContext.TemplateColumns.FindAsync(id);
            if (templateCollection == null)
                return false; // Template collection not found

            _dbContext.TemplateColumns.Remove(templateCollection);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }
    }
}
