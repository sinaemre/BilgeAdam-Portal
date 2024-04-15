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
    public class TeacherSeedData : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasData
                (
                    new Teacher 
                    {
                        Id = 1,
                        FirstName = "Sina Emre",
                        LastName = "Bekar",
                        BirthDate = new DateTime(1996,01,23),
                        Email = "sinaemre.bekar@bilgeadam.com",
                        AppUserID = "94d24825-6148-434a-85b4-259de2b77f3d"
                    }
                );
        }
    }
}
