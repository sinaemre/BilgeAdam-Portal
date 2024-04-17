using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentById(int id)
            => await _context.Students
                                .Include(x => x.Classroom)
                                .ThenInclude(x => x.Teacher)
                                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Passive);
    }
}
