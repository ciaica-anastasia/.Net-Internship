using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StudentOverallStatusConfiguration : IEntityTypeConfiguration<StudentOverallStatus>
    {
        public void Configure(EntityTypeBuilder<StudentOverallStatus> builder)
        {
            builder.HasKey(e => e.StudentOverallStatusId);
            
            builder.ToTable("Student Overall Statuses");
            
            builder.Property(e => e.StudentOverallStatusName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}