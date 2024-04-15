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
    public class StudentSeedData : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData
                (
                    new Student
                    {
                        Id = 1,
                        FirstName = "Ziya",
                        LastName = "Aygün",
                        BirthDate = new DateTime(1994, 01, 24),
                        Email = "aygun.ziya@bilgeadam.com",
                        ClassroomId = 1,
                        AppUserID = "08f6fd59-a808-46ea-aa80-bc6d85eaa2f9"
                    },
                    new Student
                    {
                        Id = 2,
                        FirstName = "Gökçe",
                        LastName = "Spor Alagöz",
                        BirthDate = new DateTime(1991, 05, 22),
                        Email = "gokce.sporalagoz@bilgeadam.com",
                        ClassroomId = 1,
                        AppUserID = "428e15d3-3141-4cb0-b245-f0201f6929c7"
                    }
                );
        }
    }
}
