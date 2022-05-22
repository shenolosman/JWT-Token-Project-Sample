using AutoMapper;
using JWT.Business.Interfaces;
using JWT.Business.StringInfos;
using JWT.Entities.Concrete;
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
        private readonly IMapper _mapper;

        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _mapper = mapper;
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
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> Register(AppUserAddDto model, [FromServices] IAppUserRoleService appUserRoleService, [FromServices] IAppRoleService appRoleService)
        {
            var user = await _appUserService.FindByUserName(model.UserName);
            if (user != null) return BadRequest($"{user.UserName} is already taken!");

            await _appUserService.Add(_mapper.Map<AppUser>(model));

            var createdUser = await _appUserService.FindByUserName(model.UserName);
            var role = await appRoleService.FindByName(RoleInfo.Member);

            await appUserRoleService.Add(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = createdUser.Id
            });

            return Created("", model);
        }

    }
}
