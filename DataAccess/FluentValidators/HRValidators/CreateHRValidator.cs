using ApplicationCore.DTO_s.HumanResourcesDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.HRValidators
{
    public class CreateHRValidator : AbstractValidator<CreateHRDTO>
    {
        public CreateHRValidator()
        {
            Regex regex = new Regex("^[a-zA-Z- ığüşöçİĞÜŞÖÇ]*$");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Ad alanı boş geçilemez!")
                .MinimumLength(3)
                .WithMessage("En az 3 karakter girmelisiniz!")
                .MaximumLength(100)
                .WithMessage("En fazla 100 karakter girebilirsiniz!")
                .Matches(regex)
                .WithMessage("Sadece harf ve \"-\" girebilirsiniz!");


            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Soyad alanı boş geçilemez!")
                .MinimumLength(2)
                .WithMessage("En az 2 karakter girmelisiniz!")
                .MaximumLength(200)
                .WithMessage("En fazla 200 karakter girebilirsiniz!")
                .Matches(regex)
                .WithMessage("Sadece harf ve \"-\" girebilirsiniz!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("E-mail alanı boş geçilemez!")
                .EmailAddress()
                .WithMessage("Lütfen doğru formatta bir mail giriniz");

            RuleFor(x => x.BirthDate)
               .NotEmpty()
               .WithMessage("Doğum tarihi alanı boş geçilemez!");

            RuleFor(x => x.HireDate)
              .NotEmpty()
              .WithMessage("İşe giriş tarihi alanı boş geçilemez!");
        }
    }
}
