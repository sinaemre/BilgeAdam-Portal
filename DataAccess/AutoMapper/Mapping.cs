using ApplicationCore.DTO_s.ClassroomDTO;
using ApplicationCore.DTO_s.StudentDTO;
using ApplicationCore.DTO_s.TeacherDTO;
using ApplicationCore.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Teacher, CreateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, ShowTeacherDTO>().ReverseMap();

            CreateMap<Student, GetStudentDetailDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Student, UpdateStudentDTO>().ReverseMap();

            CreateMap<Classroom, CreateClassroomDTO>().ReverseMap();
            CreateMap<Classroom, UpdateClassroomDTO>().ReverseMap();
        }
    }
}
