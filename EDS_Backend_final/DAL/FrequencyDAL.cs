using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class FrequencyDAL
    {
        private readonly DBContext _dbContext;

        public FrequencyDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Frequency> GetFrequencyAsync(int id)
        {
            // Implement logic to retrieve a frequency by ID from your database
            return await _dbContext.Frequency.FindAsync(id);
        }

        public async Task<IEnumerable<Frequency>> GetAllFrequenciesAsync()
        {
            // Implement logic to retrieve all Frequency from your database
            return await _dbContext.Frequency.ToListAsync();
        }

        public async Task<Frequency> CreateFrequencyAsync(Frequency frequency)
        {
            frequency.CreatedAt = DateTime.Now;
            frequency.CreatedBy = "YourName"; // Set the creator's name
            // Implement logic to create a new frequency in your database
            _dbContext.Frequency.Add(frequency);
            await _dbContext.SaveChangesAsync();
            return frequency;
        }

        public async Task<Frequency> UpdateFrequencyAsync(int id, Frequency frequency)
        {
            // Implement logic to update a frequency in your database
            var existingFrequency = await _dbContext.Frequency.FindAsync(id);
            if (existingFrequency == null)
                return null; // Frequency not found

            // Update the properties of the existing frequency with the new data
            existingFrequency.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingFrequency.UpdatedBy = frequency.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingFrequency;
        }

        public async Task<bool> DeleteFrequencyAsync(int id)
        {
            // Implement logic to delete a frequency from your database
            var frequency = await _dbContext.Frequency.FindAsync(id);
            if (frequency == null)
                return false; // Frequency not found

            _dbContext.Frequency.Remove(frequency);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }

        public async Task<int?> GetFrequencyIdAsync(string frequencyType)
        {
            var frequency = await _dbContext.Frequency
                .FirstOrDefaultAsync(f => f.FrequencyType == frequencyType);

            return frequency?.FrequencyID;
        }
    }
}
