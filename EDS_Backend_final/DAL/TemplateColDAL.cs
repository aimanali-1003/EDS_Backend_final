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

        public async Task<IEnumerable<TemplateColumns>> GetAllTemplateColsAsync()
        {
            // Implement logic to retrieve all template collections from your database
            return await _dbContext.TemplateColumns.ToListAsync();
        }

        public async Task<TemplateColumns> GetTemplateColAsync(int id)
        {
            // Implement logic to retrieve a template collection by ID from your database
            return await _dbContext.TemplateColumns.FindAsync(id);
        }

        public async Task<bool> CreateTemplateColumnsAsync(int templateId, int[] columnIds)
        {
            // Create Template Columns logic here

            // Example: Create Template Columns in the database using the passed templateId and columnIds
            foreach (var columnId in columnIds)
            {
                var templateColumn = new TemplateColumns
                {
                    TemplateID = templateId,
                    ColumnsID = columnId
                };
                templateColumn.CreatedAt = DateTime.Now;
                templateColumn.CreatedBy = "YourUsername";
                templateColumn.Active = true;
                _dbContext.TemplateColumns.Add(templateColumn); // Assuming _dbContext is your DbContext instance
            }

            await _dbContext.SaveChangesAsync(); // Save changes to the database

            return true; // return true if the template columns are successfully created
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
            try
            {
                var templateColumns = _dbContext.TemplateColumns.Where(tc => tc.TemplateID == id);
                _dbContext.TemplateColumns.RemoveRange(templateColumns);

                var template = await _dbContext.Template.FindAsync(id);
                if (template == null)
                    return false; // Template not found

                _dbContext.Template.Remove(template);
                await _dbContext.SaveChangesAsync();
                return true; // Deletion was successful
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error message
                Console.WriteLine("Error occurred during deletion: " + ex.Message);
                return false;
            }
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
    }
}
