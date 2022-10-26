using ComprasDotnet6.Application.DTOs;
using ComprasDotnet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComprasDotnet6.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> PostAsync([FromForm] UserDTO userDTO)
        {
            var result = await _userService.GenerateTokenAsync(userDTO);
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
