using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class TemplateDAL
    {
        private readonly DBContext _dbContext;

        public TemplateDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Template> GetTemplateAsync(int id)
        {
            // Implement logic to retrieve a template by ID from your database
            return await _dbContext.Template.FindAsync(id);
        }

        public async Task<IEnumerable<Template>> GetAllTemplatesAsync()
        {
            // Implement logic to retrieve all Template from your database
            return await _dbContext.Template.ToListAsync();
        }

        public async Task<Template> CreateTemplateAsync(Template template)
        {
            template.CreatedAt = DateTime.Now;
            template.CreatedBy = "YourName"; // Replace with the actual creator's name
            // Implement logic to create a new template in your database
            _dbContext.Template.Add(template);
            await _dbContext.SaveChangesAsync();
            return template;
        }

        public async Task<Template> UpdateTemplateAsync(int id, Template template)
        {
            // Implement logic to update a template in your database
            var existingTemplate = await _dbContext.Template.FindAsync(id);
            if (existingTemplate == null)
                return null; // Template not found

            // Update the properties of the existing template with the new data
            existingTemplate.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingTemplate.UpdatedBy = template.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingTemplate;
        }

        public async Task<bool> DeleteTemplateAsync(int id)
        {
            // Implement logic to delete a template from your database
            var template = await _dbContext.Template.FindAsync(id);
            if (template == null)
                return false; // Template not found

            _dbContext.Template.Remove(template);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }
    }
}
