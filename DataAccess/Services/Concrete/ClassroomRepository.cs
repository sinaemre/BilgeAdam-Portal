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
    public class ClassroomRepository : BaseRepository<Classroom>, IClassroomRepository
    {
        private readonly AppDbContext _context;

        public ClassroomRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsThereAnyStudents(int id)
            => _context.Classrooms.Include(x => x.Students).FirstOrDefaultAsync(x => x.Id == id).Result.Students.Count > 0 ? true : false;
    }
}
