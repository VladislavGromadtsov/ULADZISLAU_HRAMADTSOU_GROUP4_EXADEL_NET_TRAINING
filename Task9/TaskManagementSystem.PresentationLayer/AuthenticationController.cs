using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.BusinessLogicLayer.Authentification;
using TaskManagementSystem.BusinessLogicLayer.Models;
using TaskManagementSystem.DataAccessLayer;

namespace TaskManagementSystem.PresentationLayer
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<RoleEntity> _roleManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _authManager;

        public AuthenticationController(IMapper mapper, UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager, IAuthenticationManager authenticationManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _authManager = authenticationManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthentification user)
        {
            if (!await _authManager.ValidateUser(user))
            {
            return Unauthorized();
            }
            return Ok(new { Token = await _authManager.CreateToken() });
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistration userForRegistration)
        {
            var user = _mapper.Map<UserEntity>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            var roleExist = _roleManager.RoleExistsAsync(userForRegistration.Role).Result;
            if (roleExist)
            {
                await _userManager.AddToRoleAsync(user, userForRegistration.Role);
                return StatusCode(201);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
