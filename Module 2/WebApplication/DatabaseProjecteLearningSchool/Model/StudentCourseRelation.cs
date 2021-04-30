using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseProjecteLearningSchool.Model
{
    public class StudentCourseRelation
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int StudentCourseStatusId { get; set; }
        public bool Approved { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual StudentCourseStatus StudentCourseStatus { get; set; }
    }
}
