using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class ColumnDAL
    {
        private readonly DBContext _dbContext;

        public ColumnDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Columns> GetColumnAsync(int id)
        {
            // Implement logic to retrieve a column by ID from your database
            return await _dbContext.Columns.FindAsync(id);
        }

        public async Task<IEnumerable<Columns>> GetAllColumnsAsync()
        {
            // Implement logic to retrieve all columns from your database
            return await _dbContext.Columns.ToListAsync();
        }

        public async Task<Columns> CreateColumnAsync(Columns column)
        {
            column.CreatedAt = DateTime.Now;
            column.CreatedBy = "YourUser"; // Replace with the actual user

            // Implement logic to create a new column in your database
            _dbContext.Columns.Add(column);
            await _dbContext.SaveChangesAsync();
            return column;
        }

        public async Task<Columns> UpdateColumnAsync(int id, Columns column)
        {
            // Implement logic to update a column in your database
            var existingColumn = await _dbContext.Columns.FindAsync(id);
            if (existingColumn == null)
                return null; // Column not found

            // Update the properties of the existing column with the new data
            existingColumn.ColumnName = column.ColumnName;
            existingColumn.ColumnCode = column.ColumnCode;
            existingColumn.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingColumn.UpdatedBy = column.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingColumn;
        }

        public async Task<bool> DeleteColumnAsync(int id)
        {
            // Implement logic to delete a column from your database
            var column = await _dbContext.Columns.FindAsync(id);
            if (column == null)
                return false; // Column not found

            _dbContext.Columns.Remove(column);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }
    }
}
