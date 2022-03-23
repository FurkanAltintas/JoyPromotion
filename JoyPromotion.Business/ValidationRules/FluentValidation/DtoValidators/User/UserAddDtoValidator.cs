using FluentValidation;
using JoyPromotion.Dtos.Dtos;

namespace JoyPromotion.Business.ValidationRules.FluentValidation.DtoValidators.User
{
    public class UserAddDtoValidator : AbstractValidator<UserAddDto>
    {
        public UserAddDtoValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.SurName).NotEmpty();
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.RoleId).NotEmpty();
            RuleFor(u => u.PhoneNumber).NotEmpty();
            RuleFor(u => u.ImageUrl).NotEmpty();
        }
    }
}
