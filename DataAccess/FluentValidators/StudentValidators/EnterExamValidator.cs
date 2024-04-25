using ApplicationCore.DTO_s.StudentDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.StudentValidators
{
    public class EnterExamValidator : AbstractValidator<GetStudentDetailDTO>
    {
        public EnterExamValidator()
        {
            RuleFor(x => x.Exam1)
                .GreaterThanOrEqualTo(0)
                .WithMessage("0 ya da daha büyük bir not girişi yapınız!")
                .LessThanOrEqualTo(100)
                .WithMessage("100 ya da daha küçük bir not girişi yapınız!");

            RuleFor(x => x.Exam2)
                .GreaterThanOrEqualTo(0)
                .WithMessage("0 ya da daha büyük bir not girişi yapınız!")
                .LessThanOrEqualTo(100)
                .WithMessage("100 ya da daha küçük bir not girişi yapınız!");

            RuleFor(x => x.ProjectExam)
                .GreaterThanOrEqualTo(0)
                .WithMessage("0 ya da daha büyük bir not girişi yapınız!")
                .LessThanOrEqualTo(100)
                .WithMessage("100 ya da daha küçük bir not girişi yapınız!");
        }
    }
}
