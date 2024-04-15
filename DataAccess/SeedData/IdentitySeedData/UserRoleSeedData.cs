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
    public class UserRoleSeedData : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData
                (
                    new IdentityUserRole<string>
                    {
                        RoleId = "0ad6c1ad-52e4-4f08-9bb2-f477ad1b20f5",
                        UserId = "371caecc-777f-4249-8c7d-bbb3f27a73b8"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "637e750e-4772-414e-be79-8df14420f11e",
                        UserId = "08f6fd59-a808-46ea-aa80-bc6d85eaa2f9"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "637e750e-4772-414e-be79-8df14420f11e",
                        UserId = "428e15d3-3141-4cb0-b245-f0201f6929c7"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "ad02f608-b3f5-43e8-aac6-6f5d8900d493",
                        UserId = "94d24825-6148-434a-85b4-259de2b77f3d"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "2b5d6dba-dba7-4c5d-a24b-16119815bf87",
                        UserId = "1122d035-d752-4629-a593-ce22c8958344"
                    }
                );
        }
    }
}
