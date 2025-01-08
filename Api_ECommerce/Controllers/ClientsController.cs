using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api_ECommerce.Core.Entities;
using Api_ECommerce.Core.Interfaces;

namespace Api_ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            var clients = await _clientRepository.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Client client)
        {
            await _clientRepository.AddAsync(client);
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Client client)
        {
            if (id != client.Id)
                return BadRequest();

            var existingClient = await _clientRepository.GetByIdAsync(id);
            if (existingClient == null)
                return NotFound();

            existingClient.Nombre = client.Nombre;
            existingClient.Correo = client.Correo;
            existingClient.Direccion = client.Direccion;
            existingClient.Telefono = client.Telefono;

            await _clientRepository.UpdateAsync(existingClient);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
                return NotFound();

            await _clientRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}