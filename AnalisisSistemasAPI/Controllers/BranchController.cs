using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisSistemasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BranchController : ControllerBase
    {
        private IBranchRepository repository;

        public BranchController(IBranchRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetBranches()
        {
            var branches = repository.GetBranches();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public IActionResult GetBranch(int id)
        {
            var branches = repository.GetBranch(id);
            return Ok(branches);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Branch branch)
        {
            repository.Insert(branch);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Branch branch)
        {
            repository.Update(branch);
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
