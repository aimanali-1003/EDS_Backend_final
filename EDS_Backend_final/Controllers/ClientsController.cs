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
            var org = await _clientService.GetOrgByIdAsync(client.OrganizationID);

            if (org == null)
            {
                return NotFound("Organization not found");
            }

            var clientEntity = new Client
            {
                ClientName = client.ClientName,
                ClientCode = client.ClientCode,
                Orgs = org // Assign the Org instance to the Client's Orgs navigation property
            };

            var createdClient = await _clientService.CreateClientAsync(_mapper.Map<Client>(clientEntity));
            return CreatedAtAction(nameof(GetClient), new { id = createdClient.ClientID }, _mapper.Map<ClientViewModel>(createdClient));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientVM clientVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Fetch the existing client from the database
            var existingClient = await _clientService.GetClientAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            // Fetch the organization based on the provided organization ID in the clientVM
            var org = await _clientService.GetOrgByIdAsync(clientVM.OrganizationID);

            if (org == null)
            {
                return NotFound("Organization not found");
            }

            // Update the client's properties, including the organization
            existingClient.ClientName = clientVM.ClientName;
            existingClient.ClientCode = clientVM.ClientCode;
            existingClient.Active = clientVM.Active;
            existingClient.Orgs = org; // Update the relationship with the organization

            // Save the changes to the database
            var updatedClient = await _clientService.UpdateClientAsync(id, existingClient);

            // Map the updated client to the view model and return it
            var updatedClientVM = _mapper.Map<UpdateClientVM>(updatedClient);

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
