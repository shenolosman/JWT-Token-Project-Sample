namespace JWT.Entities.Dtos.AppUserDtos
{
    public class AppUserDto
    {
        public string UserName { get; set; }
        public string? FullName { get; set; }
        public List<string> AppUserRoles { get; set; }
    }
}
