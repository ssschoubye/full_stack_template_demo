using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DoctorType> DoctorTypes { get; set; }
        public DbSet<ShiftType> ShiftTypes { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Relationship Configuration
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.DoctorType)
                .WithMany(dt => dt.Doctors)
                .HasForeignKey(d => d.DoctorTypeId);
        }
    }
}
