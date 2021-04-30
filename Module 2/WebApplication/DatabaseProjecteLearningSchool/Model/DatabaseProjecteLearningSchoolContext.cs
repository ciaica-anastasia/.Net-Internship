using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseProjecteLearningSchool.Model
{
    public partial class DatabaseProjecteLearningSchoolContext : DbContext
    {
        public DatabaseProjecteLearningSchoolContext()
        {
        }

        public DatabaseProjecteLearningSchoolContext(DbContextOptions<DatabaseProjecteLearningSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgeRange> AgeRanges { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourseRelation> StudentCourseRelations { get; set; }
        public virtual DbSet<StudentCourseStatus> StudentCourseStatuses { get; set; }
        public virtual DbSet<StudentOverallStatus> StudentOverallStatuses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DatabaseProjecteLearningSchool;Persist Security Info=True;User ID=sa;Password=0002aciaiC!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AgeRange>(entity =>
            {
                entity.HasKey(e => e.AgeId)
                    .HasName("PK__AgeRange__8754542247406FFB");

                entity.ToTable("AgeRange");

                entity.Property(e => e.AgeRange1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("AgeRange");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Schedule)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Age)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.AgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull) //on delete no action
                    .HasConstraintName("FK__Courses__AgeId__52593CB8");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__Languag__5165187F");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.CourseLevels)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__LevelId__4F7CD00D");

                entity.HasOne(d => d.PrerequisiteNavigation)
                    .WithMany(p => p.CoursePrerequisiteNavigations)
                    .HasForeignKey(d => d.Prerequisite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__Prerequ__4E88ABD4");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__Teacher__5070F446");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.HasIndex(e => e.LanguageName, "UQ__Language__E89C4A6A024C5114")
                    .IsUnique();

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level");

                entity.HasIndex(e => e.Level1, "UQ__Level__AAF89962CDB8C0E5")
                    .IsUnique();

                entity.Property(e => e.Level1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Level");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "UQ__Students__85FB4E38D03C6E68")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Students__A9D105341C2A0484")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EnrollmentDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students__LevelI__5629CD9C");

                entity.HasOne(d => d.StudentOverallStatus)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StudentOverallStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students__Studen__571DF1D5");
            });

            modelBuilder.Entity<StudentCourseRelation>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId })
                    .HasName("PK__StudentC__5E57FC83530ED85D");

                entity.ToTable("StudentCourseRelation");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourseRelations)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__StudentCo__Cours__534D60F1");

                entity.HasOne(d => d.StudentCourseStatus)
                    .WithMany(p => p.StudentCourseRelations)
                    .HasForeignKey(d => d.StudentCourseStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentCo__Stude__5441852A");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourseRelations)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentCo__Stude__5535A963");
            });

            modelBuilder.Entity<StudentCourseStatus>(entity =>
            {
                entity.ToTable("StudentCourseStatus");

                entity.HasIndex(e => e.StudentCourseStatus1, "UQ__StudentC__4E0162B3CDFE3D37")
                    .IsUnique();

                entity.Property(e => e.StudentCourseStatus1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("StudentCourseStatus");
            });

            modelBuilder.Entity<StudentOverallStatus>(entity =>
            {
                entity.ToTable("StudentOverallStatus");

                entity.HasIndex(e => e.StudentOverallStatus1, "UQ__StudentO__80D22DD4C33443AA")
                    .IsUnique();

                entity.Property(e => e.StudentOverallStatus1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("StudentOverallStatus");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "UQ__Teachers__85FB4E3842B6FCA2")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Teachers__A9D10534E7FEAA7D")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
