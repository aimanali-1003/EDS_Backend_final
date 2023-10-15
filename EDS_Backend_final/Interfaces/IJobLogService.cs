using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface IJobLogService
    {
        Task<JobLog> GetJobLogAsync(int id);
        Task<IEnumerable<JobLog>> GetAllJobLogsAsync();
        Task<JobLog> CreateJobLogAsync(JobLog jobLog);
        Task<JobLog> UpdateJobLogAsync(int id, JobLog jobLog);
        Task<bool> DeleteJobLogAsync(int id);
    }
}
