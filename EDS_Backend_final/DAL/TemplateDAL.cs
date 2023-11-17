using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
            var resp = await _dbContext.Template
            .Where(t => !t.IsDeleted)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

            // Implement logic to retrieve all active templates from your database
            return resp;
        }


        public async Task<Template> CreateTemplateAsync(Template template)
        {
            template.CreatedAt = DateTime.Now;
            template.CreatedBy = "Zamaan";
            template.Active = true;
            _dbContext.Template.Add(template);
            await _dbContext.SaveChangesAsync();
            return template;
        }

        public async Task<(Template UpdatedTemplate, List<Job> ActiveJobs)> UpdateTemplateAsync(int id, Template template)
        {
            if (!template.Active)
            {
                var activeJobs = await _dbContext.Job
                    .Where(j => j.TemplateID == id && j.Active)
                    .ToListAsync();

                if (activeJobs.Any())
                {
                    return (null, activeJobs); 
                }
                else
                {
                    var existingTemplate = await _dbContext.Template.FindAsync(id);
                    if (existingTemplate == null)
                        return (null, null); // Template not found

                    existingTemplate.UpdatedAt = DateTime.Now;
                    existingTemplate.UpdatedBy = template.UpdatedBy;
                    existingTemplate.Active = template.Active;
                    existingTemplate.TemplateName = template.TemplateName;
                    existingTemplate.CategoryID = template.CategoryID;

                    await _dbContext.SaveChangesAsync();

                    return (existingTemplate, null);
                }

               
            }
            else
            {
                var existingTemplate = await _dbContext.Template.FindAsync(id);
                if (existingTemplate == null)
                    return (null, null); // Template not found

                existingTemplate.UpdatedAt = DateTime.Now;
                existingTemplate.UpdatedBy = template.UpdatedBy;
                existingTemplate.Active = template.Active;
                existingTemplate.TemplateName = template.TemplateName;
                existingTemplate.CategoryID = template.CategoryID;

                await _dbContext.SaveChangesAsync();

                return (existingTemplate, null);
            }
            //if (!template.Active && _dbContext.Job.Any(j => j.TemplateID == id && j.Active))
            //{
            //    var activeJobs = await _dbContext.Job
            //        .Where(j => j.TemplateID == id && j.Active)
            //        .ToListAsync();

            //    return (null, activeJobs); // Return null to indicate template not updated, and include the list of active jobs
            //}
            // Implement logic to update a template in your database

        }

        public async Task<bool> DeleteTemplateAsync(int id)
        {
            try
            {
                var templateColumns = await _dbContext.TemplateColumns.Where(tc => tc.TemplateID == id).ToListAsync();
                foreach (var templateColumn in templateColumns)
                {
                    templateColumn.Active = false;
                    templateColumn.IsDeleted = true;
                }

                var template = await _dbContext.Template.FindAsync(id);
                if (template == null)
                    return false; // Template not found
                template.Active = false;
                template.IsDeleted = true;

                await _dbContext.SaveChangesAsync();
                return true; // Soft deletion was successful
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return false; // Soft deletion failed
            }
        }

        public async Task<Category> GetOrgByIdAsync(int categoryID)
        {
            try
            {
                var category = await _dbContext.Categories.FindAsync(categoryID);
                return category;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or throw a custom exception)
                // You can also return null or a default value if organization not found
                throw;
            }
        }
        public async Task<int> GetLastCreatedTemplateIdFromDBAsync()
        {
            var lastTemplateId = await _dbContext.Template.OrderByDescending(t => t.TemplateID).Select(t => t.TemplateID).FirstOrDefaultAsync();
            return lastTemplateId;
        }

        public async Task<bool> GetJobOfTemplate(int id)
        {
            var jobExists = await _dbContext.Job.AnyAsync(j => j.TemplateID == id);
            return jobExists;
        }


    }
}
