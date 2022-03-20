using FluentValidation;
using JoyPromotion.Dtos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyPromotion.Business.ValidationRules.FluentValidation.DtoValidators
{
    public class UserPasswordDtoValidator : AbstractValidator<UserPasswordDto>
    {
        public UserPasswordDtoValidator()
        {
            RuleFor(u => u.Id).InclusiveBetween(1, int.MaxValue);
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.ConfirmPassword).NotEmpty();
            RuleFor(u => u.Password).Equal(u => u.ConfirmPassword).WithMessage("Parolalar uyuşmuyor");
        }
    }
}
