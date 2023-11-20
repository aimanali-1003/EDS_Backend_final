using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class CriteriaDAL
    {
        private readonly DBContext _dbContext;

        public CriteriaDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Criteria> GetCriteriaAsync(int id)
        {
            // Implement logic to retrieve a criteria by ID from your database
            return await _dbContext.Criteria.FindAsync(id);
        }

        public async Task<IEnumerable<Criteria>> GetAllCriteriaAsync()
        {
            // Implement logic to retrieve all Criteria from your database
            return await _dbContext.Criteria.ToListAsync();
        }

        public async Task<Criteria> CreateCriteriaAsync(Criteria criteria)
        {
            criteria.CreatedAt = DateTime.Now;
            criteria.CreatedBy = "YourCreatedByValue"; // Set the created by value as needed
            // Implement logic to create a new criteria in your database
            _dbContext.Criteria.Add(criteria);
            await _dbContext.SaveChangesAsync();
            return criteria;
        }

        public async Task<Criteria> UpdateCriteriaAsync(int id, Criteria criteria)
        {
            // Implement logic to update a criteria in your database
            var existingCriteria = await _dbContext.Criteria.FindAsync(id);
            if (existingCriteria == null)
                return null; // Criteria not found

            // Update the properties of the existing criteria with the new data
    
            existingCriteria.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingCriteria.UpdatedBy = criteria.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingCriteria;
        }

        public async Task<bool> DeleteCriteriaAsync(int id)
        {
            // Implement logic to delete a criteria from your database
            var criteria = await _dbContext.Criteria.FindAsync(id);
            if (criteria == null)
                return false; // Criteria not found

            _dbContext.Criteria.Remove(criteria);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }
    }
}
