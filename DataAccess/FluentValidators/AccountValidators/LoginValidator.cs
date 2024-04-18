using ApplicationCore.DTO_s.AccountDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.AccountValidators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Kullanıcı adı boş geçilemez!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre boş geçilemez!");
        }
    }
}
