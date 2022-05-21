using FluentValidation;
using JWT.Entities.Dtos.ProductDtos;

namespace JWT.Business.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field cant be empty");
        }
    }
}
