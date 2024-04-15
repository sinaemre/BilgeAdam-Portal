using ApplicationCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData.EntitySeedData
{
    public class ClassroomSeedData : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.HasData
                (
                    new Classroom 
                    {
                        Id = 1,
                        ClassroomName = "YZL-8743",
                        Description = "320 Saat .NET Full Stack Yazılım Uzmanlığı Eğitimi",
                        TeacherId = 1
                    }
                );
        }
    }
}
