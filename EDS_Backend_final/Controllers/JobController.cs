using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;

        public JobController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var job = await _jobService.GetJobAsync(id);
            if (job == null)
                return NotFound();

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdJob = await _jobService.CreateJobAsync(_mapper.Map<Job>(job));
            return CreatedAtAction(nameof(GetJob), new { id = createdJob.JobID }, _mapper.Map<Job>(createdJob));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] Job jobVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var job = _mapper.Map<Job>(jobVM);
            var updatedJob = await _jobService.UpdateJobAsync(id, job);
            if (updatedJob == null)
            {
                return NotFound();
            }
            var updatedJobVM = _mapper.Map<Job>(updatedJob);

            return Ok(updatedJobVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var result = await _jobService.DeleteJobAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("fileformat")]
        public async Task<IActionResult> GetFileFormat()
        {
            var fileformat = await _jobService.GetAllFileFormatsAsync();
            return Ok(fileformat);
        }
    }
}
