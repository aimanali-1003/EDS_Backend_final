using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class JobService : IJobService
    {
        private readonly JobDAL _jobDAL;

        public JobService(JobDAL jobDAL)
        {
            _jobDAL = jobDAL;
        }

        public async Task<Job> GetJobAsync(int id)
        {
            return await _jobDAL.GetJobAsync(id);
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _jobDAL.GetAllJobsAsync();
        }

        public async Task<Job> CreateJobAsync(Job job)
        {
            return await _jobDAL.CreateJobAsync(job);
        }

        public async Task<Job> UpdateJobAsync(int id, Job job)
        {
            return await _jobDAL.UpdateJobAsync(id, job);
        }

        public async Task<bool> DeleteJobAsync(int id)
        {
            return await _jobDAL.DeleteJobAsync(id);
        }

        public async Task<IEnumerable<FileFormat>> GetAllFileFormatsAsync()
        {
            return await _jobDAL.GetAllFileFormatsAsync();
        }

        public async Task<int?> GetFileFormatIdAsync(string type)
        {
            return await _jobDAL.GetFileFormatIdAsync(type);
        }

        public async Task<Job> GetJobWithRelatedEntitiesAsync(int jobId)
        {
            return await _jobDAL.GetJobWithRelatedEntitiesAsync(jobId);
        }

    }
}
