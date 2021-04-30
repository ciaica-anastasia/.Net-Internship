using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface ISchoolDbContext
    {
        DbSet<AgeRange> AgeRanges { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Level> Levels { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<StudentCourseRelation> StudentCourseRelations { get; set; }
        DbSet<StudentCourseStatus> StudentCourseStatuses { get; set; }
        DbSet<StudentOverallStatus> StudentOverallStatuses { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<StudentLevel> StudentLevels { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}