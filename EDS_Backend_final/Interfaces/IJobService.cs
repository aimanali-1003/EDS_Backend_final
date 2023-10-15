using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface IJobService
    {
        Task<Job> GetJobAsync(int id);
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job> CreateJobAsync(Job job);
        Task<Job> UpdateJobAsync(int id, Job job);
        Task<bool> DeleteJobAsync(int id);
    }
}
