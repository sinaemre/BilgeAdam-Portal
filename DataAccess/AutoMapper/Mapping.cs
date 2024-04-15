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
        }
    }
}
