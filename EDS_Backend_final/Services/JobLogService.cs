using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class JobLogService : IJobLogService
    {
        private readonly JobLogDAL _jobLogDAL;

        public JobLogService(JobLogDAL jobLogDAL)
        {
            _jobLogDAL = jobLogDAL;
        }

        public async Task<JobLog> GetJobLogAsync(int id)
        {
            return await _jobLogDAL.GetJobLogAsync(id);
        }

        public async Task<IEnumerable<JobLog>> GetAllJobLogsAsync()
        {
            return await _jobLogDAL.GetAllJobLogsAsync();
        }

        public async Task<JobLog> CreateJobLogAsync(JobLog jobLog)
        {
            return await _jobLogDAL.CreateJobLogAsync(jobLog);
        }

        public async Task<JobLog> UpdateJobLogAsync(int id, JobLog jobLog)
        {
            return await _jobLogDAL.UpdateJobLogAsync(id, jobLog);
        }

        public async Task<bool> DeleteJobLogAsync(int id)
        {
            return await _jobLogDAL.DeleteJobLogAsync(id);
        }
    }
}
