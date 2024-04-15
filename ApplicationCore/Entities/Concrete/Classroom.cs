using ApplicationCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Concrete
{
    public class Classroom : BaseEntity
    {
        public Classroom()
        {
            Students = new List<Student>();
        }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string ClassroomName { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(3)]
        public string Description { get; set; }

        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }
    }
}
