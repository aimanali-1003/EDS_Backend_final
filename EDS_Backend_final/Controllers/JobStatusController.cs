using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDS_Backend_final.Controllers
{
    [Route("api/jobstatus")]
    [ApiController]
    public class JobStatusController : ControllerBase
    {
        private readonly IJobStatusService _jobStatusService;
        private readonly IMapper _mapper;

        public JobStatusController(IJobStatusService jobStatusService, IMapper mapper)
        {
            _jobStatusService = jobStatusService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobStatuses()
        {
            var jobStatuses = await _jobStatusService.GetAllJobStatusesAsync();
            return Ok(jobStatuses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobStatus(int id)
        {
            var jobStatus = await _jobStatusService.GetJobStatusAsync(id);
            if (jobStatus == null)
                return NotFound();

            return Ok(jobStatus);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobStatus([FromBody] JobStatus jobStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdJobStatus = await _jobStatusService.CreateJobStatusAsync(_mapper.Map<JobStatus>(jobStatus));
            return CreatedAtAction(nameof(GetJobStatus), new { id = createdJobStatus.JobStatusID }, _mapper.Map<JobStatus>(createdJobStatus));
        }

        // Add PUT and DELETE actions as needed.
    }
}
