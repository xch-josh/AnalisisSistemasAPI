using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisSistemasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private IClientRepository repository;

        public ClientController(IClientRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = repository.GetClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = repository.GetClient(id);
            if (client == null)
                return NotFound();
                
            return Ok(client);
        }

        [HttpGet("document/{document}")]
        public IActionResult GetClientByDocument(string document)
        {
            var client = repository.GetClientByDocument(document);
            if (client == null)
                return NotFound();
                
            return Ok(client);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Client client)
        {
            if (client == null)
                return BadRequest();

            try
            {
                repository.Insert(client);
                return CreatedAtAction(nameof(GetClient), new { id = client.ClientId }, client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Client client)
        {
            if (client == null || client.ClientId == 0)
                return BadRequest();

            try
            {
                var existingClient = repository.GetClient(client.ClientId);
                if (existingClient == null)
                    return NotFound();

                repository.Update(client);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingClient = repository.GetClient(id);
                if (existingClient == null)
                    return NotFound();

                repository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
