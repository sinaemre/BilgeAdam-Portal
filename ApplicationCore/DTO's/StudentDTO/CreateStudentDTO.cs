using ApplicationCore.DTO_s.Abstract;
using ApplicationCore.DTO_s.ClassroomDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.StudentDTO
{
    public class CreateStudentDTO : AppUserDTO<DateTime?>
    {
        [Display(Name = "Sınıf")]
        public int? ClassroomId { get; set; }

        public List<ShowClassroomDTO>? Classrooms { get; set; }
    }
}
