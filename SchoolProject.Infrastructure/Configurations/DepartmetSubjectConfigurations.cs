using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal class DepartmetSubjectConfigurations : IEntityTypeConfiguration<DepartmetSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmetSubject> builder)
        {
            builder.HasOne(ds => ds.Department)
            .WithMany(d => d.DepartmentSubjects)
            .HasForeignKey(ds => ds.SubID);

            builder.HasOne(ds => ds.Subject)
            .WithMany(s => s.DepartmetsSubjects)
            .HasForeignKey(ds => ds.SubID);

            builder.HasKey(ds => new { ds.SubID, ds.DID });
        }
    }
}
