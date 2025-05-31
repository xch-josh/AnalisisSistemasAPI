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
            try
            {
                var branches = repository.GetBranches();

                if (branches != null)
                    return Ok(branches);
                else
                    return Ok(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBranch(int id)
        {
            try
            {
                var branch = repository.GetBranch(id);

                if (branch != null)
                    return Ok(branch);
                else
                    return Ok(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Branch branch)
        {
            try
            {
                repository.Insert(branch);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Branch branch)
        {
            try
            {
                repository.Update(branch);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                repository.Delete(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
