using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDS_Backend_final.Controllers
{
    [Route("api/notificationrecipients")]
    [ApiController]
    public class NotificationRecipientController : ControllerBase
    {
        private readonly INotificationRecipientService _notificationRecipientService;
        private readonly IMapper _mapper;

        public NotificationRecipientController(INotificationRecipientService notificationRecipientService, IMapper mapper)
        {
            _notificationRecipientService = notificationRecipientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotificationRecipients()
        {
            var recipients = await _notificationRecipientService.GetAllNotificationRecipientsAsync();
            return Ok(recipients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationRecipient(int id)
        {
            var recipient = await _notificationRecipientService.GetNotificationRecipientAsync(id);
            if (recipient == null)
                return NotFound();

            return Ok(recipient);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotificationRecipient([FromBody] NotificationRecipient recipient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdRecipient = await _notificationRecipientService.CreateNotificationRecipientAsync(_mapper.Map<NotificationRecipient>(recipient));
            return CreatedAtAction(nameof(GetNotificationRecipient), new { id = createdRecipient.NotificationRecipientID }, _mapper.Map<NotificationRecipient>(createdRecipient));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotificationRecipient(int id, [FromBody] NotificationRecipient recipientVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var recipient = _mapper.Map<NotificationRecipient>(recipientVM);
            var updatedRecipient = await _notificationRecipientService.UpdateNotificationRecipientAsync(id, recipient);
            if (updatedRecipient == null)
            {
                return NotFound();
            }
            var updatedRecipientVM = _mapper.Map<NotificationRecipient>(updatedRecipient);

            return Ok(updatedRecipientVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationRecipient(int id)
        {
            var result = await _notificationRecipientService.DeleteNotificationRecipientAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
