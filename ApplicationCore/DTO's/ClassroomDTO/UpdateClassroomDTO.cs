using ApplicationCore.DTO_s.TeacherDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.ClassroomDTO
{
    public class UpdateClassroomDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Sınıf Adı")]
        public string? ClassroomName { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Öğretmen")]
        public int? TeacherId { get; set; }

        public List<ShowTeacherDTO>? Teachers { get; set; }
    }
}
