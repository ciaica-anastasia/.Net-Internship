using Domain.Common;

namespace Domain.Entities
{
    public class StudentCourseRelation : AuditableEntity
    {
        public int StudentId { get; set; }
        public string CourseId { get; set; }
        public int StudentCourseStatusId { get; set; }
        public bool Approved { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
        public StudentCourseStatus StudentCourseStatus { get; set; }
    }
}
