using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface IJobStatusService
    {
        Task<JobStatus> GetJobStatusAsync(int id);
        Task<IEnumerable<JobStatus>> GetAllJobStatusesAsync();
        Task<JobStatus> CreateJobStatusAsync(JobStatus jobStatus);
        Task<JobStatus> UpdateJobStatusAsync(int id, JobStatus jobStatus);
        Task<bool> DeleteJobStatusAsync(int id);
    }
}
