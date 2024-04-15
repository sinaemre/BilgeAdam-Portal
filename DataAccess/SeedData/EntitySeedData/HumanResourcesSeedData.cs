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
    public class HumanResourcesSeedData : IEntityTypeConfiguration<HumanResources>
    {
        public void Configure(EntityTypeBuilder<HumanResources> builder)
        {
            builder.HasData
                (
                    new HumanResources
                    {
                        Id = 1,
                        FirstName = "Hülya",
                        LastName = "Çelebi Yılmaz",
                        Email = "hulya.celebi@bilgeadam.com",
                        BirthDate = new DateTime(1990, 02, 02),
                        HireDate = new DateTime(2021, 05, 05),
                        AppUserID = "1122d035-d752-4629-a593-ce22c8958344"
                    }
                );
        }
    }
}
