using JWT.Entities.Interfaces;

namespace JWT.Entities.Dtos.AppUserDtos
{
    public class AppUserAddDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FullName { get; set; }
    }
}
