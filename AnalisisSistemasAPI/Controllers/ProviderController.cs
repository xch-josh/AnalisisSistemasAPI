using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisSistemasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController : ControllerBase
    {
        private IProviderRepository repository;

        public ProviderController(IProviderRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetProviders()
        {
            var providers = repository.GetProviders();
            return Ok(providers);
        }

        [HttpGet("{id}")]
        public IActionResult GetProvider(int id)
        {
            var provider = repository.GetProvider(id);
            return Ok(provider);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Provider provider)
        {
            repository.Insert(provider);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Provider provider)
        {
            repository.Update(provider);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return Ok();
        }
    }
}
