using ApplicationCore.Entities.Concrete;
using DataAccess.SeedData.EntitySeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        static AppDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<HumanResources> HumanResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TeacherSeedData());
            modelBuilder.ApplyConfiguration(new ClassroomSeedData());
            modelBuilder.ApplyConfiguration(new StudentSeedData());
            modelBuilder.ApplyConfiguration(new HumanResourcesSeedData());
        }
    }
}
