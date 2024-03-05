using Microsoft.AspNetCore.Mvc;
using UserExample.Api.Inputs;
using UserExample.Model;
using UserExample.Repository;

namespace UserExample.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IRoleRepository _roleRepo;

        public UserController(IUserRepository repo, IRoleRepository roleRepo)
        {
            _repo = repo;
            _roleRepo = roleRepo;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repo.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id) 
        {
            var result = await _repo.GetById(id);

            if (result == null)
                throw new Exception("usuario no encontrado");

            return Ok(result);
        }

        [HttpGet("role/{roleName}")]
        public async Task<IActionResult> GetByRole([FromRoute] string roleName)
        {
            Role rol = await GetRole(roleName);

            var result = await _repo.GetByRole(rol.Id);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> AddUser([FromBody] UserCreationData data)
        {

            Role rol = await GetRole(data.roleName);

            User newUser = new User(data.name, data.contactInformation, data.address, data.userName, rol.Id);

            await _repo.AddAsync(newUser);

            await _repo.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var user = await _repo.GetById(id);

            if (user == null)
                throw new Exception("El usuario no es valido");

            _repo.DeleteAsync(user);

            await _repo.SaveChangesAsync();

            return Ok();
        }

        private async Task<Role> GetRole(string roleName)
        {
            var rol = await _roleRepo.GetByName(roleName);

            if (rol == null)
                throw new Exception("El rol no es valido");

            return rol;
        }
    }
}
