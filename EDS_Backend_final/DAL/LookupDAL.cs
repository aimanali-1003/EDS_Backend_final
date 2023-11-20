using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class LookupDAL
    {
        private readonly DBContext _dbContext;

        public LookupDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Lookup> GetLookupItemAsync(int id)
        {
            // Implement logic to retrieve a lookup item by ID from your database
            return await _dbContext.Lookup.FindAsync(id);
        }

        public async Task<IEnumerable<Lookup>> GetAllLookupItemsAsync()
        {
            // Implement logic to retrieve all lookup items from your database
            return await _dbContext.Lookup.ToListAsync();
        }

        public async Task<Lookup> CreateLookupItemAsync(Lookup lookup)
        {
            lookup.CreatedAt = DateTime.Now;
            lookup.CreatedBy = "Zamaan";
            // Implement logic to create a new lookup item in your database
            _dbContext.Lookup.Add(lookup);
            await _dbContext.SaveChangesAsync();
            return lookup;
        }

        public async Task<Lookup> UpdateLookupItemAsync(int id, Lookup lookup)
        {
            // Implement logic to update a lookup item in your database
            var existingLookup = await _dbContext.Lookup.FindAsync(id);
            if (existingLookup == null)
                return null; // Lookup item not found

            // Update the properties of the existing lookup item with the new data

            existingLookup.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingLookup.UpdatedBy = lookup.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingLookup;
        }

        public async Task<bool> DeleteLookupItemAsync(int id)
        {
            // Implement logic to delete a lookup item from your database
            var lookup = await _dbContext.Lookup.FindAsync(id);
            if (lookup == null)
                return false; // Lookup item not found

            _dbContext.Lookup.Remove(lookup);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }
    }
}
