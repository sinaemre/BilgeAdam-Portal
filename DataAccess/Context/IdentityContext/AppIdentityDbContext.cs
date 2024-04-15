using ApplicationCore.Entities.UserEntities.Concrete;
using DataAccess.SeedData.IdentitySeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.IdentityContext
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        static AppIdentityDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public AppIdentityDbContext()
        {
            
        }

        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserSeedData());
            builder.ApplyConfiguration(new RoleSeedData());
            builder.ApplyConfiguration(new UserRoleSeedData());
            base.OnModelCreating(builder);
        }
    }
}
