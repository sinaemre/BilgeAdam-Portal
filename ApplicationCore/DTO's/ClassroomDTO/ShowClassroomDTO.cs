using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.ClassroomDTO
{
    public class ShowClassroomDTO
    {
        public int Id { get; set; }
        public string? ClassroomName { get; set; }
        public string? ClassroomDescription { get; set; }
        public int? ClassroomSize { get; set; }
        public string? TeacherName { get; set; }
    }
}
