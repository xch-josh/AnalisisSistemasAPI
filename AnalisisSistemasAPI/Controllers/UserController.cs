using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using AnalisisSistemasAPI.Models.RolModels;
using AnalisisSistemasAPI.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AnalisisSistemasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("Session")]
        public IActionResult BeginSession([FromBody] UserSessionModel model)
        {
            try
            {
                var user = repository.BeginSession(model.Username, model.Password);

                if (user != null)
                    return Ok(user);
                else
                    return Ok(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = repository.GetUsers();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = repository.GetUser(id);

                if (user != null)
                    return Ok(user);
                else
                    return Ok(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Insert(User user)
        {
            try
            {
                repository.Insert(user);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "dfasdf");
            }
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            try
            {
                repository.Update(user);

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

        [HttpGet("BranchAccess/{id}")]
        public IActionResult GetBranchAccess(int id)
        {
            try
            {
                var access = repository.GetBranchAccess(id);

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

        [HttpPut("BranchAccess/{id}")]
        public IActionResult UpdateBranchAccess(int id, [FromBody] List<UserBranchAccessModel> model)
        {
            try
            {
                repository.UpdateBranchAccess(model, id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
