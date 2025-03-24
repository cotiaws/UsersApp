using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersApp.Application.Commands;
using UsersApp.Application.Interfaces;
using UsersApp.Application.Queries;

namespace UsersApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(UserDto), 201)]
        public async Task<IActionResult> Create([FromBody] UserCreateCommand command)
        {
            return Ok(await _userAppService.Create(command));
        }

        [HttpPost]
        [Route("auth")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public async Task<IActionResult> Auth([FromBody] UserAuthCommand command)
        {
            return Ok(await _userAppService.Auth(command));
        }

        [Authorize]
        [HttpGet]
        [Route("data")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public IActionResult Data()
        {
            return Ok(_userAppService.GetByEmail(User.Identity.Name));
        }
    }
}
