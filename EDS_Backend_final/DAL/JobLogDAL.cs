using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class JobLogDAL
    {
        private readonly DBContext _dbContext;

        public JobLogDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<JobLog> GetJobLogAsync(int id)
        {
            // Implement logic to retrieve a job log by ID from your database
            return await _dbContext.JobLog.FindAsync(id);
        }

        public async Task<IEnumerable<JobLog>> GetAllJobLogsAsync()
        {
            // Implement logic to retrieve all job logs from your database
            return await _dbContext.JobLog.ToListAsync();
        }

        public async Task<JobLog> CreateJobLogAsync(JobLog jobLog)
        {
            jobLog.CreatedAt = DateTime.Now;
            jobLog.CreatedBy = "Zamaan";
            // Implement logic to create a new job log in your database
            _dbContext.JobLog.Add(jobLog);
            await _dbContext.SaveChangesAsync();
            return jobLog;
        }

        public async Task<JobLog> UpdateJobLogAsync(int id, JobLog jobLog)
        {
            // Implement logic to update a job log in your database
            var existingJobLog = await _dbContext.JobLog.FindAsync(id);
            if (existingJobLog == null)
                return null; // Job log not found

            // Update the properties of the existing job log with the new data
            existingJobLog.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingJobLog.UpdatedBy = jobLog.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingJobLog;
        }

        public async Task<bool> DeleteJobLogAsync(int id)
        {
            // Implement logic to delete a job log from your database
            var jobLog = await _dbContext.JobLog.FindAsync(id);
            if (jobLog == null)
                return false; // Job log not found

            _dbContext.JobLog.Remove(jobLog);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }
    }
}
