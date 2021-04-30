using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.System.Commands.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly ISchoolDbContext _context;
        private readonly IUserManager _userManager;

        private readonly Dictionary<int, Level> Levels = new Dictionary<int, Level>();

        private readonly Dictionary<int, StudentCourseStatus> StudentCourseStatuses =
            new Dictionary<int, StudentCourseStatus>();

        private readonly Dictionary<int, Language> Languages = new Dictionary<int, Language>();

        private readonly Dictionary<int, StudentOverallStatus> StudentOverallStatuses =
            new Dictionary<int, StudentOverallStatus>();

        private readonly Dictionary<int, AgeRange> AgeRanges = new Dictionary<int, AgeRange>();
        private readonly Dictionary<int, Student> Students = new Dictionary<int, Student>();
        private readonly Dictionary<int, Course> Courses = new Dictionary<int, Course>();
        private readonly Dictionary<int, Teacher> Teachers = new Dictionary<int, Teacher>();

        public SampleDataSeeder(ISchoolDbContext context, IUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (_context.Courses.Any())
            {
                return;
            }

            await SeedLevelsAsync(cancellationToken);
            await SeedStudentCourseStatusesAsync(cancellationToken);
            await SeedLanguagesAsync(cancellationToken);
            await SeedStudentOverallStatusesAsync(cancellationToken);
            await SeedAgeRangesAsync(cancellationToken);
            await SeedTeachersAsync(cancellationToken);
            await SeedCoursesAsync(cancellationToken);
            await SeedUsersAsync(cancellationToken);
            //3 tables: students, studentcourserealtion, studentlevels
        }

        private async Task SeedUsersAsync(CancellationToken cancellationToken)
        {
            var students = await _context.Students
                .Include(s => s.StudentCourseRelations)
                .ToListAsync(cancellationToken);

            if (students.Any())
            {
                foreach (var student in students)
                {
                    var userName = $"{student.FirstName}@eschool".ToLower();
                    var result = await _userManager.CreateUserAsync(userName, "eSchool1!");
                    student.UserId = result.UserId;
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        private async Task SeedCoursesAsync(CancellationToken cancellationToken)
        {
            var courses = new[]
            {
                new Course
                {
                    CourseId = "EN11", Capacity = 30, Schedule = "Mon/Fri 9 - 10:25", LevelId = 1, TeacherId = 1,
                    LanguageId = 1, Duration = "1 year", Price = 100,
                    Description = "Beginner English class for preschool", AgeId = 1
                },
                new Course
                {
                    CourseId = "EN21", Capacity = 18, Schedule = "Tue/Thu 10:45 - 12:10", LevelId = 2,
                    TeacherId = 2, LanguageId = 1, Duration = "1 year", Price = 100,
                    Description = "Elementary English class for school", PrerequisiteId = 1, AgeId = 2
                },
                new Course
                {
                    CourseId = "EN31", Capacity = 17, Schedule = "Mon/Fri 9 - 10:25", LevelId = 3, TeacherId = 2,
                    LanguageId = 1, Duration = "1 year", Price = 100,
                    Description = "Pre-intermediate English  class for school", AgeId = 2
                },
                new Course
                {
                    CourseId = "EN41", Capacity = 17, Schedule = "Mon/Fri 9 - 10:25", LevelId = 4, TeacherId = 3,
                    LanguageId = 1, Duration = "1 year", Price = 100,
                    Description = "Intermediate English  speaking class for adults", AgeId = 3, Purpose = "Speaking"
                },
                new Course
                {
                    CourseId = "EN42", Capacity = 17, Schedule = "Mon/Fri 9 - 10:25", LevelId = 4, TeacherId = 3,
                    LanguageId = 1, Duration = "1 year", Price = 100,
                    Description = "Intermediate English  business class for adults", AgeId = 3, Purpose = "Business"
                },
                new Course
                {
                    CourseId = "ES11", Capacity = 23, Schedule = "Mon/Fri 9 - 10:25", LevelId = 1, TeacherId = 4,
                    LanguageId = 2, Duration = "1 year", Price = 100,
                    Description = "Beginner Spanish class for preschool", AgeId = 1
                },
                new Course
                {
                    CourseId = "ES21", Capacity = 27, Schedule = "Mon/Fri 9 - 10:25", LevelId = 2, TeacherId = 5,
                    LanguageId = 2, Duration = "1 year", Price = 100,
                    Description = "Elementary Spanish class for school", AgeId = 2
                },
                new Course
                {
                    CourseId = "ES31", Capacity = 21, Schedule = "Mon/Fri 9 - 10:25", LevelId = 3, TeacherId = 6,
                    LanguageId = 2, Duration = "1 year", Price = 100,
                    Description = "Pre-intermediate Spanish class for school", AgeId = 2
                },
                new Course
                {
                    CourseId = "DE11", Capacity = 16, Schedule = "Mon/Fri 9 - 10:25", LevelId = 1, TeacherId = 7,
                    LanguageId = 3, Duration = "1 year", Price = 100,
                    Description = "Beginner German class for adults", AgeId = 3
                },
                new Course
                {
                    CourseId = "DE21", Capacity = 24, Schedule = "Mon/Fri 9 - 10:25", LevelId = 2, TeacherId = 8,
                    LanguageId = 3, Duration = "1 year", Price = 100,
                    Description = "Elementary German class for adults", AgeId = 3
                }
            };

            _context.Courses.AddRange(courses);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedLevelsAsync(CancellationToken cancellationToken)
        {
            var levels = new[]
            {
                new Level {LevelId = 1, LevelName = "Beginner"},
                new Level {LevelId = 2, LevelName = "Elementary"},
                new Level {LevelId = 3, LevelName = "Pre-Intermediate"},
                new Level {LevelId = 4, LevelName = "Intermediate"},
                new Level {LevelId = 5, LevelName = "Upper-Intermediate"},
                new Level {LevelId = 6, LevelName = "Advanced"},
                new Level {LevelId = 7, LevelName = "Proficiency"}
            };

            _context.Levels.AddRange(levels);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedStudentCourseStatusesAsync(CancellationToken cancellationToken)
        {
            var statuses = new[]
            {
                new StudentCourseStatus() {StudentCourseStatusId = 1, StudentCourseStatusName = "Waiting for start"},
                new StudentCourseStatus() {StudentCourseStatusId = 2, StudentCourseStatusName = "In progress"},
                new StudentCourseStatus() {StudentCourseStatusId = 3, StudentCourseStatusName = "Finished"},
                new StudentCourseStatus() {StudentCourseStatusId = 4, StudentCourseStatusName = "Freezed"}
            };

            _context.StudentCourseStatuses.AddRange(statuses);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedLanguagesAsync(CancellationToken cancellationToken)
        {
            var languages = new[]
            {
                new Language() {LanguageId = 1, LanguageName = "English"},
                new Language() {LanguageId = 2, LanguageName = "Spanish"},
                new Language() {LanguageId = 3, LanguageName = "German"},
                new Language() {LanguageId = 4, LanguageName = "French"}
            };

            _context.Languages.AddRange(languages);

            await _context.SaveChangesAsync(cancellationToken);
        }
        
        private async Task SeedStudentOverallStatusesAsync(CancellationToken cancellationToken)
        {
            var statuses = new[]
            {
                new StudentOverallStatus() {StudentOverallStatusId = 1, StudentOverallStatusName = "Registered"},
                new StudentOverallStatus() {StudentOverallStatusId = 2, StudentOverallStatusName = "Pending"},
                new StudentOverallStatus() {StudentOverallStatusId = 3, StudentOverallStatusName = "Active"},
                new StudentOverallStatus() {StudentOverallStatusId = 4, StudentOverallStatusName = "Inactive"}
            };

            _context.StudentOverallStatuses.AddRange(statuses);

            await _context.SaveChangesAsync(cancellationToken);
        }
        
        private async Task SeedAgeRangesAsync(CancellationToken cancellationToken)
        {
            var ranges = new[]
            {
                new AgeRange() {AgeId = 1, AgeRangeName = "Preschool"},
                new AgeRange() {AgeId = 1, AgeRangeName = "School"},
                new AgeRange() {AgeId = 1, AgeRangeName = "Adults"}
            };

            _context.AgeRanges.AddRange(ranges);

            await _context.SaveChangesAsync(cancellationToken);
        }
        
        private async Task SeedTeachersAsync(CancellationToken cancellationToken)
        {
            var teachers = new[]
            {
                new Teacher() {TeacherId = 1, FirstName = "Yael", LastName = "Hicks", PhoneNumber = "084720141", Email = "mauris.sagittis@augue.net", Description = "Beginner English teacher for preschool"},
                new Teacher() {TeacherId = 2, FirstName = "Carly", LastName = "Howard", PhoneNumber = "089077007", Email = "non.dui@ligulaAenean.co.uk", Description = "Elementary and Pre-Intermediate English teacher for school"},
                new Teacher() {TeacherId = 3, FirstName = "Ulysses", LastName = "Mccarthy", PhoneNumber = "047361636", Email = "non.dapibus.rutrum@magnaa.edu", Description = "Intermediate English speaking and business teacher for adults"},
                new Teacher() {TeacherId = 4, FirstName = "Georgia", LastName = "Wallace", PhoneNumber = "063430511", Email = "Nunc@Mauriseuturpis.edu", Description = "Beginner Spanish teacher for preschool"},
                new Teacher() {TeacherId = 5, FirstName = "Aristotle", LastName = "Hill", PhoneNumber = "009180636", Email = "Donec.porttitor@variusorciin.net", Description = "Elementary Spanish teacher for school"},
                new Teacher() {TeacherId = 6, FirstName = "Blaze", LastName = "Vance", PhoneNumber = "071229364", Email = "dictum.ultricies.ligula@pellentesque.co.uk", Description = "Pre-Intermediate Spanish teacher for school"},
                new Teacher() {TeacherId = 7, FirstName = "James", LastName = "Carter", PhoneNumber = "074205290", Email = "arcu@leoelementumsem.org", Description = "Beginner German teacher for adults"},
                new Teacher() {TeacherId = 8, FirstName = "Candice", LastName = "Bauer", PhoneNumber = "085764677", Email = "elit.Curabitur@velvulputateeu.edu", Description = "Elementary German teacher for adults"},
                new Teacher() {TeacherId = 9, FirstName = "Iola", LastName = "Dalton", PhoneNumber = "035432471", Email = "eros.non@Crasinterdum.org", Description = "TOEFL prep English teacher for adults"},
                new Teacher() {TeacherId = 10, FirstName = "Russell", LastName = "Fuller", PhoneNumber = "094663084", Email = "Aliquam.vulputate@utaliquamiaculis.net", Description = "DaF prep German teacher for adults"}
            };
            
            _context.Teachers.AddRange(teachers);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}