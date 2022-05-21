using FluentValidation;
using JWT.Entities.Dtos.ProductDtos;

namespace JWT.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue);
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field must be filled!");
        }
    }
}
