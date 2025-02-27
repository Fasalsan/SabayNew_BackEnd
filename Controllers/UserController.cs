using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabayNew.Models;
using SabayNew.Repository.User;

namespace SabayNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult>GetAll()
        {
            var uerList = await _userRepository.GetAll();
            return Ok(uerList);
        }


        [HttpPost("Post")]
        public async Task<IActionResult> Save(UserModel user)
        {
            var userList = await _userRepository.Save(user);
            return Ok(userList);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserModel user, int id)
        {
            var roleList = await _userRepository.Update(user,id);
            return Ok(roleList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var userList = await _userRepository.GetById(id); ;
            return Ok(userList);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var roleList = await _userRepository.Delete(id);
            return Ok(roleList);
        }
    }
}
