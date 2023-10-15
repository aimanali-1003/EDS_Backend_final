using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface ICriteriaService
    {
        Task<Criteria> GetCriteriaAsync(int id);
        Task<IEnumerable<Criteria>> GetAllCriteriaAsync();
        Task<Criteria> CreateCriteriaAsync(Criteria criteria);
        Task<Criteria> UpdateCriteriaAsync(int id, Criteria criteria);
        Task<bool> DeleteCriteriaAsync(int id);
    }
}
