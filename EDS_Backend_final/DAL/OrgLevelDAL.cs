using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class OrgLevelDAL
    {
        private readonly DBContext _dbContext;

        public OrgLevelDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<OrgLevel> GetOrgLevelAsync(int id)
        {
            // Implement logic to retrieve an organizational level by ID from your database
            return await _dbContext.OrgLevel.FindAsync(id);
        }

        public async Task<IEnumerable<OrgLevel>> GetAllOrgLevelsAsync()
        {
            // Implement logic to retrieve all organizational levels from your database
            return await _dbContext.OrgLevel.ToListAsync();
        }

        public async Task<OrgLevel> CreateOrgLevelAsync(OrgLevel orgLevel)
        {
            orgLevel.CreatedAt = DateTime.Now;
            orgLevel.CreatedBy = "YourUserName"; // Replace with the actual user
            // Implement logic to create a new organizational level in your database
            _dbContext.OrgLevel.Add(orgLevel);
            await _dbContext.SaveChangesAsync();
            return orgLevel;
        }

        public async Task<OrgLevel> UpdateOrgLevelAsync(int id, OrgLevel orgLevel)
        {
            // Implement logic to update an organizational level in your database
            var existingOrgLevel = await _dbContext.OrgLevel.FindAsync(id);
            if (existingOrgLevel == null)
                return null; // Organizational level not found

            // Update the properties of the existing organizational level with the new data
            existingOrgLevel.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingOrgLevel.UpdatedBy = orgLevel.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingOrgLevel;
        }

        public async Task<bool> DeleteOrgLevelAsync(int id)
        {
            // Implement logic to delete an organizational level from your database
            var orgLevel = await _dbContext.OrgLevel.FindAsync(id);
            if (orgLevel == null)
                return false; // Organizational level not found

            _dbContext.OrgLevel.Remove(orgLevel);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }
    }
}
