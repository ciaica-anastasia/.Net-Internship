using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Course : AuditableEntity
    {
        public Course()
        {
            StudentCourseRelations = new HashSet<StudentCourseRelation>();
        }

        public string CourseId { get; set; }
        public int Capacity { get; set; }
        public string Schedule { get; set; }
        public int LevelId { get; set; }
        public int? TeacherId { get; set; }
        public int LanguageId { get; set; }
        public string Duration { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int? PrerequisiteId { get; set; }
        public int? AgeId { get; set; }
        public string Purpose { get; set; }

        public AgeRange Age { get; set; }
        public Language Language { get; set; }
        public Level Level { get; set; }
        public Level PrerequisiteLevel { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<StudentCourseRelation> StudentCourseRelations { get; private set; }
    }
}
