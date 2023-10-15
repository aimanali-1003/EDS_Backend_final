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
    [Route("api/joblogs")]
    [ApiController]
    public class JobLogController : ControllerBase
    {
        private readonly IJobLogService _jobLogService;
        private readonly IMapper _mapper;

        public JobLogController(IJobLogService jobLogService, IMapper mapper)
        {
            _jobLogService = jobLogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobLogs()
        {
            var jobLogs = await _jobLogService.GetAllJobLogsAsync();
            return Ok(jobLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobLog(int id)
        {
            var jobLog = await _jobLogService.GetJobLogAsync(id);
            if (jobLog == null)
                return NotFound();

            return Ok(jobLog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobLog([FromBody] JobLog jobLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdJobLog = await _jobLogService.CreateJobLogAsync(_mapper.Map<JobLog>(jobLog));
            return CreatedAtAction(nameof(GetJobLog), new { id = createdJobLog.JobLogID }, _mapper.Map<JobLog>(createdJobLog));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobLog(int id, [FromBody] JobLog jobLogVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobLog = _mapper.Map<JobLog>(jobLogVM);
            var updatedJobLog = await _jobLogService.UpdateJobLogAsync(id, jobLog);
            if (updatedJobLog == null)
            {
                return NotFound();
            }
            var updatedJobLogVM = _mapper.Map<JobLog>(updatedJobLog);

            return Ok(updatedJobLogVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobLog(int id)
        {
            var result = await _jobLogService.DeleteJobLogAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
