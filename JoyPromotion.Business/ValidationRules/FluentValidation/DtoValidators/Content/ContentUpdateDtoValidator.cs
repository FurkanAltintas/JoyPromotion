using FluentValidation;
using JoyPromotion.Dtos.Dtos;

namespace JoyPromotion.Business.ValidationRules.FluentValidation.DtoValidators
{
    public class ContentUpdateDtoValidator : AbstractValidator<ContentUpdateDto>
    {
        public ContentUpdateDtoValidator()
        {
            RuleFor(c => c.Id).InclusiveBetween(1, int.MaxValue);
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ImageUrl).NotEmpty();
            RuleFor(C => C.CategoryId).InclusiveBetween(1, int.MaxValue);
        }
    }
}
