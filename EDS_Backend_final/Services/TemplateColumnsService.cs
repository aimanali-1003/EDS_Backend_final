using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class TemplateColumnsService : ITemplateColsService
    {
        private readonly TemplateColDAL _templateColumnsDAL;

        public TemplateColumnsService(TemplateColDAL templateColumnsDAL)
        {
            _templateColumnsDAL = templateColumnsDAL;
        }

        public async Task<TemplateColumns> GetTemplateColAsync(int id)
        {
            return await _templateColumnsDAL.GetTemplateColAsync(id);
        }

        public async Task<IEnumerable<TemplateColumns>> GetAllTemplateColsAsync()
        {
            return await _templateColumnsDAL.GetAllTemplateColsAsync();
        }

        public async Task<TemplateColumns> CreateTemplateColAsync(TemplateColumns templateColumn)
        {
            return await _templateColumnsDAL.CreateTemplateColAsync(templateColumn);
        }

        public async Task<TemplateColumns> UpdateTemplateColAsync(int id, TemplateColumns templateColumn)
        {
            return await _templateColumnsDAL.UpdateTemplateColAsync(id, templateColumn);
        }

        public async Task<bool> DeleteTemplateColAsync(int id)
        {
            return await _templateColumnsDAL.DeleteTemplateColAsync(id);
        }
    }
}
