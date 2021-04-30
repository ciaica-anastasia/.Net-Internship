using System.Collections.Generic;

namespace Domain.Entities
{
    public class StudentCourseStatus
    {
        public StudentCourseStatus()
        {
            StudentCourseRelations = new HashSet<StudentCourseRelation>();
        }

        public int StudentCourseStatusId { get; set; }
        public string StudentCourseStatusName { get; set; }

        public ICollection<StudentCourseRelation> StudentCourseRelations { get; private set; }
    }
}
