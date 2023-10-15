using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDS_Backend_final.Controllers
{
    [Route("api/datarecipients")]
    [ApiController]
    public class DataRecipientController : ControllerBase
    {
        private readonly IDataRecipientService _dataRecipientService;
        private readonly IMapper _mapper;

        public DataRecipientController(IDataRecipientService dataRecipientService, IMapper mapper)
        {
            _dataRecipientService = dataRecipientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDataRecipients()
        {
            var dataRecipients = await _dataRecipientService.GetAllDataRecipientsAsync();
            return Ok(dataRecipients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDataRecipient(int id)
        {
            var dataRecipient = await _dataRecipientService.GetDataRecipientAsync(id);
            if (dataRecipient == null)
                return NotFound();

            return Ok(dataRecipient);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDataRecipient([FromBody] DataRecipient dataRecipient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdDataRecipient = await _dataRecipientService.CreateDataRecipientAsync(_mapper.Map<DataRecipient>(dataRecipient));
            return CreatedAtAction(nameof(GetDataRecipient), new { id = createdDataRecipient.RecipientID }, _mapper.Map<DataRecipient>(createdDataRecipient));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDataRecipient(int id, [FromBody] DataRecipient dataRecipientVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dataRecipient = _mapper.Map<DataRecipient>(dataRecipientVM);
            var updatedDataRecipient = await _dataRecipientService.UpdateDataRecipientAsync(id, dataRecipient);
            if (updatedDataRecipient == null)
            {
                return NotFound();
            }
            var updatedDataRecipientVM = _mapper.Map<DataRecipient>(updatedDataRecipient);

            return Ok(updatedDataRecipientVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataRecipient(int id)
        {
            var result = await _dataRecipientService.DeleteDataRecipientAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
