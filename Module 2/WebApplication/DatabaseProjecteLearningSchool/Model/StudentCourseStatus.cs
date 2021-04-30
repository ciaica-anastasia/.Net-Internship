using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseProjecteLearningSchool.Model
{
    public class StudentCourseStatus
    {
        public StudentCourseStatus()
        {
            StudentCourseRelations = new HashSet<StudentCourseRelation>();
        }

        public int StudentCourseStatusId { get; set; }
        public string StudentCourseStatus1 { get; set; }

        public virtual ICollection<StudentCourseRelation> StudentCourseRelations { get; set; }
    }
}
