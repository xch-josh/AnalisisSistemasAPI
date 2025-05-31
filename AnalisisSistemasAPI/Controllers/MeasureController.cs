using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisSistemasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasureController : ControllerBase
    {
        private IMeasureRepository repository;

        public MeasureController(IMeasureRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetMeasures()
        {
            var measures = repository.GetMeasures();
            return Ok(measures);
        }

        [HttpGet("{id}")]
        public IActionResult GetMeasure(int id)
        {
            var measure = repository.GetMeasure(id);
            return Ok(measure);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Measure measure)
        {
            repository.Insert(measure);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Measure measure)
        {
            repository.Update(measure);
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
