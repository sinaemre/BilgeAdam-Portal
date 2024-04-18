using ApplicationCore.DTO_s.ClassroomDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.ClassroomValidators
{
    public class UpdateClassroomValidator : AbstractValidator<UpdateClassroomDTO>
    {
        public UpdateClassroomValidator()
        {
            Regex regex = new Regex("^[a-zA-Z- .ığüşöçİĞÜŞÖÇ0123456789]*$");

            RuleFor(x => x.ClassroomName)
                .NotEmpty()
                .WithMessage("Sınıf adı boş geçilemez!")
                .MinimumLength(3)
                .WithMessage("En az 3 karakter girmelisiniz!")
                .MaximumLength(100)
                .WithMessage("En fazla 100 karakter girebilirsiniz!")
                .Matches(regex)
                .WithMessage("Sadece sayı, harf ve \"-\" girebilirsiniz!");

            RuleFor(x => x.Description)
              .NotEmpty()
              .WithMessage("Açıklama boş geçilemez!")
              .MinimumLength(3)
              .WithMessage("En az 3 karakter girmelisiniz!")
              .MaximumLength(200)
              .WithMessage("En fazla 200 karakter girebilirsiniz!")
              .Matches(regex)
              .WithMessage("Sadece sayı, harf ve \"-\" girebilirsiniz!");


            RuleFor(x => x.TeacherId)
              .NotEmpty()
              .WithMessage("Öğretmen boş geçilemez!");

        }
    }
}
