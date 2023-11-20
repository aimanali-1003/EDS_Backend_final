using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class JobStatusService : IJobStatusService
    {
        private readonly JobStatusDAL _jobStatusDAL;

        public JobStatusService(JobStatusDAL jobStatusDAL)
        {
            _jobStatusDAL = jobStatusDAL;
        }

        public async Task<JobStatus> GetJobStatusAsync(int id)
        {
            return await _jobStatusDAL.GetJobStatusAsync(id);
        }

        public async Task<IEnumerable<JobStatus>> GetAllJobStatusesAsync()
        {
            return await _jobStatusDAL.GetAllJobStatusesAsync();
        }

        public async Task<JobStatus> CreateJobStatusAsync(JobStatus jobStatus)
        {
            return await _jobStatusDAL.CreateJobStatusAsync(jobStatus);
        }

        public async Task<JobStatus> UpdateJobStatusAsync(int id, JobStatus jobStatus)
        {
            return await _jobStatusDAL.UpdateJobStatusAsync(id, jobStatus);
        }

        public async Task<bool> DeleteJobStatusAsync(int id)
        {
            return await _jobStatusDAL.DeleteJobStatusAsync(id);
        }
    }
}
