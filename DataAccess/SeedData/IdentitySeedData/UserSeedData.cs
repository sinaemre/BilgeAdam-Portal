using ApplicationCore.Entities.UserEntities.Concrete;
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
    public class UserSeedData : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();

            var admin = new AppUser
            {
                Id = "371caecc-777f-4249-8c7d-bbb3f27a73b8",
                FirstName = "Yönetici",
                LastName = "Admin",
                BirthDate = new DateTime(2000, 01, 01),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@bilgeadam.com",
                NormalizedEmail = "ADMIN@BILGEADAM.COM",
                PasswordHash = hasher.HashPassword(null, "123")
            };

            var humanResources = new AppUser
            {
                Id = "1122d035-d752-4629-a593-ce22c8958344",
                FirstName = "Hülya",
                LastName = "Çelebi Yılmaz",
                BirthDate = new DateTime(1990, 02, 02),
                UserName = "hulya.celebi",
                NormalizedUserName = "HULYA.CELEBI",
                Email = "hulya.celebi@bilgeadam.com",
                NormalizedEmail = "HULYA.CELEBI@BILGEADAM.COM",
                PasswordHash = hasher.HashPassword(null, "123")
            };

            var teacher = new AppUser
            {
                Id = "94d24825-6148-434a-85b4-259de2b77f3d",
                FirstName = "Sina Emre",
                LastName = "Bekar",
                BirthDate = new DateTime(1996, 01, 23),
                UserName = "sinaemre.bekar",
                NormalizedUserName = "SINAEMRE.BEKAR",
                Email = "sinaemre.bekar@bilgeadam.com",
                NormalizedEmail = "SINAEMRE.BEKAR@BILGEADAM.COM",
                PasswordHash = hasher.HashPassword(null, "123")
            };

            var student1 = new AppUser
            {
                Id = "08f6fd59-a808-46ea-aa80-bc6d85eaa2f9",
                FirstName = "Ziya",
                LastName = "Aygün",
                BirthDate = new DateTime(1994, 01, 24),
                UserName = "ziya.aygun",
                NormalizedUserName = "ZIYA.AYGUN",
                Email = "aygun.ziya@bilgeadam.com",
                NormalizedEmail = "AYGUN.ZIYA@BILGEADAM.COM",
                PasswordHash = hasher.HashPassword(null, "123")
            };

            var student2 = new AppUser
            {
                Id = "428e15d3-3141-4cb0-b245-f0201f6929c7",
                FirstName = "Gökçe",
                LastName = "Spor Alagöz",
                BirthDate = new DateTime(1991, 05, 22),
                UserName = "gokce.sporalagoz",
                NormalizedUserName = "GOKCE.SPORALAGOZ",
                Email = "gokce.sporalagoz@bilgeadam.com",
                NormalizedEmail = "GOKCE.SPORALAGOZ@BILGEADAM.COM",
                PasswordHash = hasher.HashPassword(null, "123")
            };

            builder.HasData(admin, humanResources, teacher, student1, student2);

        }
    }
}
