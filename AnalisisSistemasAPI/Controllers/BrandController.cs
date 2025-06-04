using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisSistemasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private IBrandRepository repository;

        public BrandController(IBrandRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetBrands()
        {
            var brands = repository.GetBrands();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult GetBrand(int id)
        {
            var brand = repository.GetBrand(id);
            return Ok(brand);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Brand brand)
        {
            repository.Insert(brand);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Brand brand)
        {
            repository.Update(brand);
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
