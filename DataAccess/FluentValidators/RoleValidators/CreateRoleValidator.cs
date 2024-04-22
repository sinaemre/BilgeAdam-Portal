using ApplicationCore.DTO_s.RoleDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.RoleValidators
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleDTO>
    {
        public CreateRoleValidator()
        {
            Regex regex = new Regex("^[a-zA-Z-]*$");

            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("Rol adı boş geçilemez!")
                .MinimumLength(2)
                .WithMessage("En az 2 karakter girmelisiniz!")
                .MaximumLength(100)
                .WithMessage("En fazla 100 karakter girebilirsiniz!")
                .Matches(regex)
                .WithMessage("Türkçe karakter, sayı ve özel karakter giremezsiniz.");
        }
    }
}
