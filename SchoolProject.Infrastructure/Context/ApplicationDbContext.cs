using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<DepartmetSubject> departmetSubjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmetSubject>()
                .HasKey(ds => new { ds.SubID, ds.DID });
            modelBuilder.Entity<Ins_Subject>()
                .HasKey(Is => new { Is.SubId, Is.InsId});
            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.SubID, ss.StudID });

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.SuperVisor)
                .WithMany(i => i.SupervisedInstructors)
                .HasForeignKey(i => i.SuperVisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithOne(i => i.DepartmentManaged)
                .HasForeignKey<Department>(x => x.InsManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
