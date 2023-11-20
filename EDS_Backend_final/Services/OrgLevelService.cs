using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class OrgLevelService : IOrgLevelService
    {
        private readonly OrgLevelDAL _orgLevelDAL;

        public OrgLevelService(OrgLevelDAL orgLevelDAL)
        {
            _orgLevelDAL = orgLevelDAL;
        }

        public async Task<OrgLevel> GetOrgLevelAsync(int id)
        {
            return await _orgLevelDAL.GetOrgLevelAsync(id);
        }

        public async Task<IEnumerable<OrgLevel>> GetAllOrgLevelsAsync()
        {
            return await _orgLevelDAL.GetAllOrgLevelsAsync();
        }

        public async Task<OrgLevel> CreateOrgLevelAsync(OrgLevel orgLevel)
        {
            return await _orgLevelDAL.CreateOrgLevelAsync(orgLevel);
        }

        public async Task<OrgLevel> UpdateOrgLevelAsync(int id, OrgLevel orgLevel)
        {
            return await _orgLevelDAL.UpdateOrgLevelAsync(id, orgLevel);
        }

        public async Task<bool> DeleteOrgLevelAsync(int id)
        {
            return await _orgLevelDAL.DeleteOrgLevelAsync(id);
        }
    }
}
