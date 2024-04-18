using ApplicationCore.DTO_s.AccountDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.AccountValidators
{
    public class EditUserValidator : AbstractValidator<EditUserDTO>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.Email)
              .NotEmpty()
              .WithMessage("E-mail alanı boş geçilemez!")
              .EmailAddress()
              .WithMessage("Lütfen doğru formatta bir mail giriniz");
        }
    }
}
