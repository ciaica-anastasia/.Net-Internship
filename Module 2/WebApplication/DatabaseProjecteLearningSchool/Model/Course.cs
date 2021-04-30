using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseProjecteLearningSchool.Model
{
    public partial class Course
    {
        public Course()
        {
            StudentCourseRelations = new HashSet<StudentCourseRelation>();
        }

        public int CourseId { get; set; }
        public int Capacity { get; set; }
        public string Schedule { get; set; }
        public int LevelId { get; set; }
        public int TeacherId { get; set; }
        public int LanguageId { get; set; }
        public string Duration { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Prerequisite { get; set; }
        public int AgeId { get; set; }

        public virtual AgeRange Age { get; set; }
        public virtual Language Language { get; set; }
        public virtual Level Level { get; set; }
        public virtual Level PrerequisiteNavigation { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<StudentCourseRelation> StudentCourseRelations { get; set; }
    }
}
