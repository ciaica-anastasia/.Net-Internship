using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseProjecteLearningSchool.Model
{
    public class Student
    {
        public Student()
        {
            StudentCourseRelations = new HashSet<StudentCourseRelation>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int LevelId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Password { get; set; }
        public int StudentOverallStatusId { get; set; }

        public virtual Level Level { get; set; }
        public virtual StudentOverallStatus StudentOverallStatus { get; set; }
        public virtual ICollection<StudentCourseRelation> StudentCourseRelations { get; set; }
    }
}
