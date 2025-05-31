using AnalisisSistemasAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisSistemasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        IPermissionRepository repository;

        public PermissionController(IPermissionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetPermissions()
        {
            try
            {
                var permissions = repository.GetPermissions();

                return Ok(permissions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
