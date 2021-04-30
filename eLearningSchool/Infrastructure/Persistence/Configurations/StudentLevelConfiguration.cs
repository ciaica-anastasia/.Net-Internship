using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StudentLevelConfiguration : IEntityTypeConfiguration<StudentLevel>
    {
        public void Configure(EntityTypeBuilder<StudentLevel> builder)
        {
            builder.HasKey(e => e.StudentId);
            
            builder.ToTable("Student Levels");
            
            builder.HasOne(d => d.Level)
                .WithMany(p => p.StudentLevels)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK_Levels_StudentLevels");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.StudentLevels)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Languages_StudentLevels");

            builder.HasOne(d => d.Student)
                .WithMany(p => p.StudentLevels)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentLevels_Students");
        }
    }
}