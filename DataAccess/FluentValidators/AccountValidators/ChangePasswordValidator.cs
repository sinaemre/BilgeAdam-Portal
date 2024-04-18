using ApplicationCore.DTO_s.AccountDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.AccountValidators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .WithMessage("Eski şifre boş geçilemez!");

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .WithMessage("Yeni şifre boş geçilemez!")
                .NotEqual(x => x.OldPassword)
                .WithMessage("Yeni şifreniz eski şifrenizle aynı olamaz!");

            RuleFor(x => x.PasswordCheck)
                .NotEmpty()
                .WithMessage("Yeni şifre tekrar boş geçilemez!")
                .Equal(x => x.NewPassword)
                .WithMessage("Şifreler eşleşmiyor!");
        }
    }
}
