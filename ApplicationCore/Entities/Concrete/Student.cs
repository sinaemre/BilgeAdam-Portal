using ApplicationCore.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Concrete
{
    public class Student : BaseEntity
    {
        [Required]
        public string AppUserID { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Range(0, 100)]
        public double? Exam1 { get; set; }

        [Range(0, 100)]
        public double? Exam2 { get; set; }

        [Range(0, 100)]
        public double? ProjectExam { get; set; }

        public double? Average
        {
            get
            {
                if (Exam1 != null && Exam2 != null && ProjectExam != null)
                {
                    return (0.25 * Exam1) + (0.25 * Exam2) + (0.5 * ProjectExam);
                }
                return null;
            }
        }

        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

        public string? ProjectPath { get; set; }

        public string? ProjectName { get; set; }

        [NotMapped]
        public IFormFile? Project { get; set; }

        public string? ImagePath { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
