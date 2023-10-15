using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EDS_Backend_final.Controllers
{
    [Route("api/frequencies")]
    [ApiController]
    public class FrequencyController : ControllerBase
    {
        private readonly IFrequencyService _frequencyService;
        private readonly IMapper _mapper;

        public FrequencyController(IFrequencyService frequencyService, IMapper mapper)
        {
            _frequencyService = frequencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFrequencies()
        {
            var frequencies = await _frequencyService.GetAllFrequenciesAsync();
            return Ok(frequencies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFrequency(int id)
        {
            var frequency = await _frequencyService.GetFrequencyAsync(id);
            if (frequency == null)
                return NotFound();

            return Ok(frequency);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFrequency([FromBody] Frequency frequency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdFrequency = await _frequencyService.CreateFrequencyAsync(_mapper.Map<Frequency>(frequency));
            return CreatedAtAction(nameof(GetFrequency), new { id = createdFrequency.FrequencyID }, _mapper.Map<Frequency>(createdFrequency));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFrequency(int id, [FromBody] Frequency frequencyVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var frequency = _mapper.Map<Frequency>(frequencyVM);
            var updatedFrequency = await _frequencyService.UpdateFrequencyAsync(id, frequency);
            if (updatedFrequency == null)
            {
                return NotFound();
            }
            var updatedFrequencyVM = _mapper.Map<Frequency>(updatedFrequency);

            return Ok(updatedFrequencyVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrequency(int id)
        {
            var result = await _frequencyService.DeleteFrequencyAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
