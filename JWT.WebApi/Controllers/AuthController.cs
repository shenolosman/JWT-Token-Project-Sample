using JWT.Business.Interfaces;
using JWT.Entities.Dtos.AppUserDtos;
using JWT.WebApi.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace JWT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;

        public AuthController(IJwtService jwtService, IAppUserService appUserService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
        }
        [HttpGet("[action]")]
        [ValidModel]
        public async Task<IActionResult> Signin(AppUserLoginDto model)
        {
            var appUser = await _appUserService.FindByUserName(model.UserName);
            if (appUser == null) return BadRequest("Username or Password is wrong!");
            if (!await _appUserService.CheckPassword(model)) return BadRequest("Username or Password is wrong!");

            var roles = await _appUserService.GetRolesByUserName(model.UserName);
            if (roles == null) return BadRequest("User roles are empty!");

            var token = _jwtService.GenerateJwtToken(appUser, roles);

            return Created("", token);
        }
    }
}
