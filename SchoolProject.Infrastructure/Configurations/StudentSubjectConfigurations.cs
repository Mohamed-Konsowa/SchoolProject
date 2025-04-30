using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal class StudentSubjectConfigurations : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudID);

            builder.HasOne(ss => ss.Subject)
            .WithMany(s => s.StudentsSubjects)
            .HasForeignKey(ss => ss.SubID);

            builder.HasKey(ss => new { ss.SubID, ss.StudID });
        }
    }
}
