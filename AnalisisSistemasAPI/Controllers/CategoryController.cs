using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisSistemasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository repository;

        public CategoryController(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = repository.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = repository.GetCategory(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Category category)
        {
            repository.Insert(category);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Category category)
        {
            repository.Update(category);
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
