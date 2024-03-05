using Microsoft.AspNetCore.Mvc;
using UserExample.Api.Inputs;
using UserExample.Model;
using UserExample.Repository;

namespace UserExample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repo.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var result = await _repo.GetById(id);

            if (result == null)
                throw new Exception("rol no encontrado");

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> AddRole([FromBody] RoleCreationData data)
        {
            Role role = new(data.roleName, data.description, data.permissionType);

            await _repo.AddAsync(role);
            await _repo.SaveChangesAsync();
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole([FromRoute] string id)
        {
            var role = await _repo.GetById(id);

            if (role == null)
                throw new Exception("No se encontro el rol");

            _repo.DeleteAsync(role);
            await _repo.SaveChangesAsync();
            return Ok();
        }
    }
}
