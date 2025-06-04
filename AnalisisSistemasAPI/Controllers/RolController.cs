using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using AnalisisSistemasAPI.Models.RolModels;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisSistemasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : ControllerBase
    {
        IRolRepository repository;

        public RolController(IRolRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            try
            {
                var roles = repository.GetRoles();

                if (roles.Count > 0)
                {
                    return Ok(roles);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRol(int id)
        {
            var roles = repository.GetRol(id);
            return Ok(roles);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Rol rol)
        {
            try
            {
                repository.Insert(rol);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "dfasdf");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Rol rol)
        {
            try
            {
                repository.Update(rol);

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

        [HttpGet("Access/{id}")]
        public IActionResult GetAccess(int id)
        {
            try
            {
                var access = repository.GetAccess(id);

                if (access != null && access.Count > 0)
                    return Ok(access);
                else
                    return Ok(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ModuleAccess/{id}")]
        public IActionResult GetModuleAccess(int id)
        {
            try
            {
                var access = repository.GetModuleAccess(id);

                if (access != null && access.Count > 0)
                    return Ok(access);
                else
                    return Ok(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ModuleAccess/{id}")]
        public IActionResult UpdateModuleAccess(int id, [FromBody] List<RolModuleAccessModel> model)
        {
            try
            {
                repository.UpdateModuleAccess(model, id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
