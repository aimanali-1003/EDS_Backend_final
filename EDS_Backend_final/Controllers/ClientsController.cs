using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientService.GetClientAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] ClientViewModel client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdClient = await _clientService.CreateClientAsync(_mapper.Map<Client>(client));
            return CreatedAtAction(nameof(GetClient), new { id = createdClient.ClientID }, _mapper.Map<ClientViewModel>(createdClient));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientViewModel clientVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = _mapper.Map<Client>(clientVM);
            var updatedClient = await _clientService.UpdateClientAsync(id, client);
            if (updatedClient == null)
            {
                return NotFound();
            }
            var updatedClientVM = _mapper.Map<ClientViewModel>(updatedClient);

            return Ok(updatedClientVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var result = await _clientService.DeleteClientAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
