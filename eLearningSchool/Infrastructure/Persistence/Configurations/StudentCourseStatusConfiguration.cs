using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StudentCourseStatusConfiguration : IEntityTypeConfiguration<StudentCourseStatus>
    {
        public void Configure(EntityTypeBuilder<StudentCourseStatus> builder)
        {
            builder.HasKey(e => e.StudentCourseStatusId);
            
            builder.ToTable("Student Course Statuses");
            
            builder.Property(e => e.StudentCourseStatusName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}