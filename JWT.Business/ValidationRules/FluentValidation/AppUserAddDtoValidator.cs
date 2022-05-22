using FluentValidation;
using JWT.Entities.Dtos.AppUserDtos;

namespace JWT.Business.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username must be filled");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must be filled");
            RuleFor(x => x.FullName).MaximumLength(100);
        }
    }
}
