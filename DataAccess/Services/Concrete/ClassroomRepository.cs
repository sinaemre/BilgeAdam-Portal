using ApplicationCore.Entities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class ClassroomRepository : BaseRepository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(AppDbContext context) : base(context)
        {
        }
    }
}
