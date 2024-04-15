using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData.IdentitySeedData
{
    public class RoleSeedData : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var admin = new IdentityRole
            {
                Id = "0ad6c1ad-52e4-4f08-9bb2-f477ad1b20f5",
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var student = new IdentityRole
            {
                Id = "637e750e-4772-414e-be79-8df14420f11e",
                Name = "student",
                NormalizedName = "STUDENT"
            };

            var teacher = new IdentityRole
            {
                Id = "ad02f608-b3f5-43e8-aac6-6f5d8900d493",
                Name = "teacher",
                NormalizedName = "TEACHER"
            };

            var humanResources = new IdentityRole
            {
                Id = "2b5d6dba-dba7-4c5d-a24b-16119815bf87",
                Name = "humanResources",
                NormalizedName = "HUMANRESOURCES"
            };

            builder.HasData(admin, student, teacher, humanResources);
        }
    }
}
