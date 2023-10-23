using AutoMapper;
using EDS_Backend_final.DataContext;
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
        private IFrequencyService _frequencyService;
        private IDataRecipientService _recipientService;
        private readonly DBContext _dbContext;

        public JobController(IJobService jobService, IMapper mapper, IFrequencyService frequencyService, IDataRecipientService recipientService, DBContext dbContext)
        {
            _jobService = jobService;
            _mapper = mapper;
            _frequencyService = frequencyService;
            _recipientService = recipientService;
            _dbContext = dbContext;
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
        public async Task<IActionResult> CreateJob([FromBody] JobViewModel job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _dbContext.Clients.FindAsync(job.ClientID);
            var dataRecipientType = await _dbContext.DataRecipientType.FindAsync(job.RecipientTypeID);

            //var dataRecipient = new DataRecipient
            //    {
            //        Client = client,
            //    DataRecipientType = dataRecipientType,
            //        // Other properties as needed
            //    };

            var dataRecipient = new DataRecipient
            {
                ClientID = job.ClientID,
                RecipientTypeID = job.RecipientTypeID
            };

            var createDataRecipient = await _recipientService.CreateDataRecipientAsync(_mapper.Map<DataRecipient>(dataRecipient));


            int? frequencyid = await _frequencyService.GetFrequencyIdAsync(job.FrequencyType);

            int? fileformatid = await _jobService.GetFileFormatIdAsync(job.FileFormatType);
            var jobEntity = new Job
            {
                // Map other properties from the JobViewModel as needed
                FrequencyID = (int)frequencyid,
                JobType = job.JobType,
                Active = (bool)job.Active,
                FileFormatID = (int)fileformatid,


    };

            var createdJob = await _jobService.CreateJobAsync(_mapper.Map<Job>(job));
            return CreatedAtAction(nameof(GetJob), new { id = createdJob.JobID }, _mapper.Map<JobViewModel>(createdJob));
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
