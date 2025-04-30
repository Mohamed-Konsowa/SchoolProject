using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasOne(i => i.SuperVisor)
                .WithMany(i => i.SupervisedInstructors)
                .HasForeignKey(i => i.SuperVisorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
