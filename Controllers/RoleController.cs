using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabayNew.Models;
using SabayNew.Repository.Role;

namespace SabayNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
                _roleRepository = roleRepository;
        }

        [HttpPost("Post")]
        public async Task<IActionResult>Save(RoleModel roleModel)
        {
            var roleList = await _roleRepository.Save(roleModel);
            return Ok(roleList);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult>Delete(int id)
        {
            var roleList = await _roleRepository.Delete( id);
            return Ok(roleList);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var roleList = await _roleRepository.GetAll();
            return Ok(roleList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult>GetById(int id)
        {
            var roleList = await _roleRepository.GetById(id); ;
            return Ok(roleList);
        }

        [HttpPut("Update")]
        public async Task<IActionResult>Update(int id , RoleModel roleModel)
        {
            var roleList = await _roleRepository.Update(id, roleModel);
            return Ok(roleList);
        }

    }
}
