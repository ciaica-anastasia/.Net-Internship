using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            
            builder.HasKey(e => e.CourseId);
            
            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.Property(e => e.Duration)
                .HasMaxLength(100);

            builder.Property(e => e.Schedule)
                .HasMaxLength(100);

            builder.HasOne(d => d.Age)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.AgeId)
                .OnDelete(DeleteBehavior.ClientSetNull) //on delete no action
                .HasConstraintName("FK_Courses_AgeRanges");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Languages");

            builder.HasOne(d => d.Level)
                .WithMany(p => p.CourseLevels)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Levels");

            builder.HasOne(d => d.PrerequisiteLevel)
                .WithMany(p => p.CoursePrerequisiteLevels)
                .HasForeignKey(d => d.PrerequisiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_PrerequisiteLevels");

            builder.HasOne(d => d.Teacher)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Courses__Teachers");
        }
    }
}