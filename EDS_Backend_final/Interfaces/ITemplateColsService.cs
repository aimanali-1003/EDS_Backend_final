using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface ITemplateColsService
    {
        Task<TemplateColumns> GetTemplateColAsync(int id);
        Task<IEnumerable<TemplateColumns>> GetAllTemplateColsAsync();
        Task<TemplateColumns> CreateTemplateColAsync(TemplateColumns templateCol);
        Task<TemplateColumns> UpdateTemplateColAsync(int id, TemplateColumns templateCol);
        Task<bool> DeleteTemplateColAsync(int id);
    }
}
