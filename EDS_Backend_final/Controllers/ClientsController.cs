using AutoMapper;
using EDS_Backend_final.Exceptions;
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
            try
            {
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
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientVM clientVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var client = _mapper.Map<Client>(clientVM);

                var org = await _clientService.GetOrgByIdAsync(clientVM.OrganizationID);

                if (org == null)
                {
                    return NotFound("Organization not found");
                }
                //var clientExistsInJobTable = await _clientService.CheckIfClientExistsInJobTableAsync(id);

                //if (clientExistsInJobTable)
                //{
                //    return BadRequest("Cannot deactivate the client as it exists in the job table.");
                //}

                var updatedClient = await _clientService.UpdateClientAsync(id, client);

                var updatedClientVM = _mapper.Map<UpdateClientVM>(updatedClient);

                return Ok(updatedClientVM);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var result = await _clientService.DeleteClientAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("{clientId}/Organizations")]
        public async Task<IActionResult> GetOrganizationsForClient(int clientId)
        {
            try
            {
                var orgViewModels = await _clientService.GetOrganizationsForClientAsync(clientId);
                return Ok(orgViewModels);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log or return an error response)
                return StatusCode(500, "An error occurred while retrieving organizations for the client.");
            }
        }
    }
}
