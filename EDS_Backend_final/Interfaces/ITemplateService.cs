﻿using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface ITemplateService
    {
        Task<Template> GetTemplateAsync(int id);
        Task<IEnumerable<Template>> GetAllTemplatesAsync();
        Task<Template> CreateTemplateAsync(Template template);
        Task<Template> UpdateTemplateAsync(int id, Template template);
        Task<bool> DeleteTemplateAsync(int id);
    }
}
