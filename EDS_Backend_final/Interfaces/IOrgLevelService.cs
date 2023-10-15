using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface IOrgLevelService
    {
        Task<OrgLevel> GetOrgLevelAsync(int id);
        Task<IEnumerable<OrgLevel>> GetAllOrgLevelsAsync();
        Task<OrgLevel> CreateOrgLevelAsync(OrgLevel orgLevel);
        Task<OrgLevel> UpdateOrgLevelAsync(int id, OrgLevel orgLevel);
        Task<bool> DeleteOrgLevelAsync(int id);
    }
}
