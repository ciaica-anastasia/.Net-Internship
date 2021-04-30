using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Student : AuditableEntity
    {
        public Student()
        {
            StudentCourseRelations = new HashSet<StudentCourseRelation>();
            StudentLevels = new HashSet<StudentLevel>();
        }

        public int StudentId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public int? StudentOverallStatusId { get; set; }
        
        public StudentOverallStatus StudentOverallStatus { get; set; }
        public ICollection<StudentCourseRelation> StudentCourseRelations { get; private set; }
        public ICollection<StudentLevel> StudentLevels { get; private set; }
    }
}
