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
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public JobController(IJobService jobService, IMapper mapper, IFrequencyService frequencyService, IDataRecipientService recipientService, DBContext dbContext)
        {
            _jobService = jobService;
            _mapper = mapper;
            _frequencyService = frequencyService;
            _recipientService = recipientService;
            _dbContext = dbContext;
            jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Other serialization options, if needed
            };
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

            Job job = await _jobService.GetJobWithRelatedEntitiesAsync(id);

            if (job != null)
            {
                // Serialize the Job entity with circular references handled
                string serializedJob = JsonSerializer.Serialize(job, jsonSerializerOptions);
                return Content(serializedJob, "application/json");
            }

            return NotFound(); // Job not found
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

            var dataRecipient = new DataRecipient
            {
                ClientID = job.ClientID,
                RecipientTypeID = job.RecipientTypeID,
                Client = client,
                
            };

            //var createDataRecipient = await _recipientService.CreateDataRecipientAsync(_mapper.Map<DataRecipient>(dataRecipient));


            int? frequencyid = await _frequencyService.GetFrequencyIdAsync(job.FrequencyType);

            //int DataRecipientID = createDataRecipient.RecipientID;
            int DataRecipientID = 1;
            int? fileformatid = await _jobService.GetFileFormatIdAsync(job.FileFormatType);
            var jobEntity = new Job
            {
                FileFormatID = (int)fileformatid,
                DataRecipientID = DataRecipientID,
                FrequencyID = (int)frequencyid,
                //TemplateID = job.TemplateID,
                TemplateID = 1,
                JobID = job.JobID,
                JobType = job.JobType,
                StartDate = job.StartTime,
                EndDate = job.EndTime,
                Client = client,
                ClientID = job.ClientID

            };
            Console.WriteLine(jobEntity);

            var createdJob = await _jobService.CreateJobAsync(_mapper.Map<Job>(jobEntity));
            string serializedJob = JsonSerializer.Serialize(createdJob, jsonSerializerOptions);
            return Content(serializedJob, "application/json");
            //return CreatedAtAction(nameof(GetJob), new { id = createdJob.JobID }, createdJob);

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
