using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class DataRecipientDAL
    {
        private readonly DBContext _dbContext;

        public DataRecipientDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<DataRecipient> GetDataRecipientAsync(int id)
        {
            // Implement logic to retrieve a data recipient by ID from your database
            return await _dbContext.DataRecipient.FindAsync(id);
        }

        public async Task<IEnumerable<DataRecipient>> GetAllDataRecipientsAsync()
        {
            // Implement logic to retrieve all data recipients from your database
            return await _dbContext.DataRecipient.ToListAsync();
        }

        public async Task<DataRecipient> CreateDataRecipientAsync(DataRecipient dataRecipient)
        {
            dataRecipient.CreatedAt = DateTime.Now;
            dataRecipient.CreatedBy = "YourName"; // Update with the appropriate user
            dataRecipient.Active = true;

            // Implement logic to create a new data recipient in your database
            _dbContext.DataRecipient.Add(dataRecipient);
            await _dbContext.SaveChangesAsync();
            return dataRecipient;
        }

        public async Task<DataRecipient> UpdateDataRecipientAsync(int id, DataRecipient dataRecipient)
        {
            // Implement logic to update a data recipient in your database
            var existingDataRecipient = await _dbContext.DataRecipient.FindAsync(id);
            if (existingDataRecipient == null)
                return null; // Data recipient not found

            // Update the properties of the existing data recipient with the new data

            existingDataRecipient.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingDataRecipient.UpdatedBy = dataRecipient.UpdatedBy; // Update with your actual user

            await _dbContext.SaveChangesAsync();
            return existingDataRecipient;
        }

        public async Task<bool> DeleteDataRecipientAsync(int id)
        {
            // Implement logic to delete a data recipient from your database
            var dataRecipient = await _dbContext.DataRecipient.FindAsync(id);
            if (dataRecipient == null)
                return false; // Data recipient not found

            _dbContext.DataRecipient.Remove(dataRecipient);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }

        public async Task<IEnumerable<DataRecipientType>> GetAllDataRecipientTypesAsync()
        {
            return await _dbContext.DataRecipientType.ToListAsync();
        }
    }
}
