using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StudentCourseRelationConfiguration : IEntityTypeConfiguration<StudentCourseRelation>
    {
        public void Configure(EntityTypeBuilder<StudentCourseRelation> builder)
        {
            builder.ToTable("Student Course Relations");
            
            builder.HasKey(e => new {e.StudentId, e.CourseId})
                .IsClustered(false);

            builder.HasOne(d => d.Course)
                .WithMany(p => p.StudentCourseRelations)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_StudentCourseRelations_Courses");

            builder.HasOne(d => d.StudentCourseStatus)
                .WithMany(p => p.StudentCourseRelations)
                .HasForeignKey(d => d.StudentCourseStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentCourseRelations_StudentCourseStatus");

            builder.HasOne(d => d.Student)
                .WithMany(p => p.StudentCourseRelations)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentCourseRelations_Students");
        }
    }
}