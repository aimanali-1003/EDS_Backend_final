using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class JobStatusDAL
    {
        private readonly DBContext _dbContext;

        public JobStatusDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<JobStatus> GetJobStatusAsync(int id)
        {
            // Implement logic to retrieve a job status by ID from your database
            return await _dbContext.JobStatus.FindAsync(id);
        }

        public async Task<IEnumerable<JobStatus>> GetAllJobStatusesAsync()
        {
            // Implement logic to retrieve all job statuses from your database
            return await _dbContext.JobStatus.ToListAsync();
        }

        public async Task<JobStatus> CreateJobStatusAsync(JobStatus jobStatus)
        {
            jobStatus.CreatedAt = DateTime.Now;
            jobStatus.CreatedBy = "YourCreatedByValue";
            // Implement logic to create a new job status in your database
            _dbContext.JobStatus.Add(jobStatus);
            await _dbContext.SaveChangesAsync();
            return jobStatus;
        }

        public async Task<JobStatus> UpdateJobStatusAsync(int id, JobStatus jobStatus)
        {
            // Implement logic to update a job status in your database
            var existingJobStatus = await _dbContext.JobStatus.FindAsync(id);
            if (existingJobStatus == null)
                return null; // Job status not found

            // Update the properties of the existing job status with the new data
            existingJobStatus.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingJobStatus.UpdatedBy = jobStatus.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingJobStatus;
        }

        public async Task<bool> DeleteJobStatusAsync(int id)
        {
            // Implement logic to delete a job status from your database
            var jobStatus = await _dbContext.JobStatus.FindAsync(id);
            if (jobStatus == null)
                return false; // Job status not found

            _dbContext.JobStatus.Remove(jobStatus);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }
    }
}
