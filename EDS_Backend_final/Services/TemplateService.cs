using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly TemplateDAL _templateDAL;

        public TemplateService(TemplateDAL templateDAL)
        {
            _templateDAL = templateDAL;
        }

        public async Task<Template> GetTemplateAsync(int id)
        {
            return await _templateDAL.GetTemplateAsync(id);
        }

        public async Task<IEnumerable<Template>> GetAllTemplatesAsync()
        {
            return await _templateDAL.GetAllTemplatesAsync();
        }

        public async Task<Template> CreateTemplateAsync(Template template)
        {
            return await _templateDAL.CreateTemplateAsync(template);
        }

        public async Task<Template> UpdateTemplateAsync(int id, Template template)
        {
            return await _templateDAL.UpdateTemplateAsync(id, template);
        }

        public async Task<bool> DeleteTemplateAsync(int id)
        {
            return await _templateDAL.DeleteTemplateAsync(id);
        }

        public async Task<Category> GetOrgByIdAsync(int categoryID)
        {
            return await _templateDAL.GetOrgByIdAsync(categoryID);
        }
        public async Task<int> GetLastCreatedTemplateIdAsync()
        {
            var lastTemplateId = await _templateDAL.GetLastCreatedTemplateIdFromDBAsync();
            return lastTemplateId;
        }



    }
}
