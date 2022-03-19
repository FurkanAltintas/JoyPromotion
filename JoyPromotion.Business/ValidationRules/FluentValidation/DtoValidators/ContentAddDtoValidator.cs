using FluentValidation;
using JoyPromotion.Dtos.Dtos;

namespace JoyPromotion.Business.ValidationRules.FluentValidation.DtoValidators
{
    public class ContentAddDtoValidator : AbstractValidator<ContentAddDto>
    {
        public ContentAddDtoValidator()
        {
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ImageUrl).NotEmpty();
            RuleFor(C => C.CategoryId).InclusiveBetween(1, int.MaxValue).NotEmpty();
        }
    }
}
