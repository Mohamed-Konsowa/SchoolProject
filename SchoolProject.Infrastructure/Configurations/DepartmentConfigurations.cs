using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DID);
            builder.Property(d => d.DNameAr).HasMaxLength(500);

            builder.HasMany(d => d.Students)
            .WithOne(s => s.Department)
            .HasForeignKey(s => s.DID)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Manager)
                .WithOne(i => i.DepartmentManaged)
                .HasForeignKey<Department>(d => d.InsManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
