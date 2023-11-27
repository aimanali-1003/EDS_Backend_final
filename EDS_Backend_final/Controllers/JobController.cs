﻿using AutoMapper;
using EDS_Backend_final.DataContext;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
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

            var createDataRecipient = await _recipientService.CreateDataRecipientAsync(_mapper.Map<DataRecipient>(dataRecipient));


            int? frequencyid = await _frequencyService.GetFrequencyIdAsync(job.FrequencyType);

            int DataRecipientID = createDataRecipient.RecipientID;
            int? fileformatid = await _jobService.GetFileFormatIdAsync(job.FileFormatType);
            var jobEntity = new Job
            {
                FileFormatID = (int)fileformatid,
                DataRecipientID = DataRecipientID,
                FrequencyID = (int)frequencyid,
                TemplateID = job.TemplateID,
                JobID = job.JobID,
                JobType = job.JobType,
                StartDate = job.StartDate,
                ClientID = job.ClientID,
                StartTime = job.StartTime,
                DayofWeek_Lkp = job.DayofWeek_Lkp,
                NotificationCheck = job.NotificationCheck,
                MinRecordCountAlarm = job.MinRecordCountAlarm,
                MaxRecordCountAlarm = job.MaxRecordCountAlarm,
                MinRunDurationAlarm = job.MinRunDurationAlarm,
                MaxRunDurationAlarm = job.MaxRunDurationAlarm
            };
            Console.WriteLine(jobEntity);

            var createdJob = await _jobService.CreateJobAsync(_mapper.Map<Job>(jobEntity));
            string serializedJob = JsonSerializer.Serialize(createdJob, jsonSerializerOptions);

            var templateColumnsIds = await _dbContext.TemplateColumns
                .Where(tc => tc.TemplateID == job.TemplateID)
                .Select(tc => tc.ColumnsID)
                .ToListAsync();
             
            int[] columnsIdsArray = templateColumnsIds.ToArray();
             
            var allColumns = await _dbContext.Columns
                .Where(c => columnsIdsArray.Contains(c.ColumnsID))
                .ToListAsync(); 

            var columnDictionary = allColumns.ToDictionary(c => c.ColumnsID, c => c.ColumnName);
             
            var orderedColumnNames = new List<string>();
             
            foreach (var columnId in columnsIdsArray)
            {
                if (columnDictionary.TryGetValue(columnId, out string columnName))
                {
                    orderedColumnNames.Add(columnName);
                }
            }
              

            string[] columnNamesArray = orderedColumnNames.ToArray();

            var template = await _dbContext.Template.FindAsync(job.TemplateID);
            string templateName = template?.TemplateName ?? "DefaultTemplateName"; // Set a default name if the template is not found

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Columns");
                 
                for (int i = 0; i < columnNamesArray.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = columnNamesArray[i];
                     
                    for (int j = 0; j < 5; j++)
                    {
                        worksheet.Cells[j + 2, i + 1].Value = $"{columnNamesArray[i]} - Record {j + 1}";
                    }
                }
                 
                var stream = new MemoryStream();
                package.SaveAs(stream);

                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string filePath = Path.Combine(downloadsPath, $"{templateName}.xlsx");

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    stream.Position = 0;
                    await stream.CopyToAsync(fileStream);
                }

                // Replace "recipientEmail" with the actual recipient's email address
                string recipientEmail = "zamaan.net.dev@gmail.com";

                // Call the method to send the email with the generated Excel file as an attachment
                await _jobService.SendEmailWithAttachment(filePath, recipientEmail);
            }
             
            return Content(serializedJob, "application/json");

        }

        



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] JobViewModel job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Load the existing Job entity from the database by its ID
            var existingJob = await _dbContext.Job.FindAsync(id);

            if (existingJob == null)
            {
                return NotFound(); // Job with the specified ID not found
            }

            // Update the properties of the existing Job entity with the values from JobViewModel
            existingJob.TemplateID = job.TemplateID;
            existingJob.JobID = job.JobID;
            existingJob.JobType = job.JobType;
            existingJob.StartDate = job.StartDate;
            existingJob.ClientID = job.ClientID;
            existingJob.StartTime = job.StartTime;
            existingJob.DayofWeek_Lkp = job.DayofWeek_Lkp;
            existingJob.NotificationCheck = job.NotificationCheck;
            existingJob.MinRecordCountAlarm = job.MinRecordCountAlarm;
            existingJob.MaxRecordCountAlarm = job.MaxRecordCountAlarm;
            existingJob.MinRunDurationAlarm = job.MinRunDurationAlarm;
            existingJob.MaxRunDurationAlarm = job.MaxRunDurationAlarm;
            //existingJob.Active = job.Active;

            var existingDataRecipient = await _dbContext.DataRecipient.FindAsync(existingJob.DataRecipientID);

            existingDataRecipient.RecipientTypeID = job.RecipientTypeID;
            existingJob.UpdatedBy = "M.Zamaan";


            _dbContext.Job.Update(existingJob);
            _dbContext.DataRecipient.Update(existingDataRecipient);
            await _dbContext.SaveChangesAsync();

            // Optionally, you can return the updated job data in the response
            string serializedJob = JsonSerializer.Serialize(existingJob, jsonSerializerOptions);
            return Content(serializedJob, "application/json");
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
