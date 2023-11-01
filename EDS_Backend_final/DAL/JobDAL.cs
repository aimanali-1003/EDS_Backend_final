using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class JobDAL
    {
        private readonly DBContext _dbContext;

        public JobDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Job> GetJobAsync(int id)
        {
            // Implement logic to retrieve a job by ID from your database
            return await _dbContext.Job.FindAsync(id);
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            // Implement logic to retrieve all Job from your database
            return await _dbContext.Job.ToListAsync();
        }

        public async Task<Job> CreateJobAsync(Job job)
        {
            job.CreatedAt = DateTime.Now;
            job.CreatedBy = "YourUserName"; // Replace with the actual user name
            job.Active = true;

            _dbContext.Job.Add(job);
            await _dbContext.SaveChangesAsync();
            return job;
        }

        public async Task<Job> UpdateJobAsync(int id, Job job)
        {
            var existingJob = await _dbContext.Job.FindAsync(id);
            if (existingJob == null)
                return null; // Job not found


            existingJob.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingJob.UpdatedBy = job.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingJob;
        }

        public async Task<bool> DeleteJobAsync(int id)
        {
            // Implement logic to delete a job from your database
            var job = await _dbContext.Job.FindAsync(id);
            if (job == null)
                return false; // Job not found

            _dbContext.Job.Remove(job);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }

        public async Task<IEnumerable<FileFormat>> GetAllFileFormatsAsync()
        {
            return await _dbContext.FileFormat.ToListAsync();
        }

        public async Task<int?> GetFileFormatIdAsync(string type)
        {
            var fileformatid = await _dbContext.FileFormat
               .FirstOrDefaultAsync(f => f.FileFormatName == type);

            return fileformatid?.FileFormatID;
        }

        public async Task<Job> GetJobWithRelatedEntitiesAsync(int jobId)
        {

            //return await _dbContext.Job
            //    .Include(job => job.Frequency)
            //    .Include(job => job.Template)
            //    .Include(job => job.FileFormat)
            //    .Include(job => job.DataRecipient)
            //    .ThenInclude(dr => dr.DataRecipientType)
            //    .FirstOrDefaultAsync(job => job.JobID == jobId);
            var job = await _dbContext.Job
        .Include(job => job.Frequency)
        .Include(job => job.Template)
        .Include(job => job.FileFormat)
        .Include(job => job.DataRecipient)
        .Include(job => job.Client)
        .FirstOrDefaultAsync(job => job.JobID == jobId);

            // Include RecipientTypeName from DataRecipientType
            if (job != null)
            {
                var recipientType = _dbContext.DataRecipientType
                    .FirstOrDefault(dr => dr.RecipientTypeID == job.DataRecipient.RecipientTypeID);

                if (recipientType != null)
                {
                    job.DataRecipient.DataRecipientType = recipientType;
                }
            }

            return job;
        }
    }
}
