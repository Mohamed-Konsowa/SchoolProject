using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal class Ins_SubjectConfigurations : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder.HasOne(Is => Is.Instructor)
                .WithMany(i => i.Ins_Subjects)
                .HasForeignKey(Is => Is.InsId);

            builder.HasOne(Is => Is.Subject)
                .WithMany(s => s.Ins_Subjects)
                .HasForeignKey(Is => Is.SubId);

            builder.HasKey(Is => new { Is.SubId, Is.InsId });
        }
    }
}
