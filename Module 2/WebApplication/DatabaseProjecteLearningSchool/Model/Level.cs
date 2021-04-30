using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseProjecteLearningSchool.Model
{
    public partial class Level
    {
        public Level()
        {
            CourseLevels = new HashSet<Course>();
            CoursePrerequisiteNavigations = new HashSet<Course>();
            Students = new HashSet<Student>();
        }

        public int LevelId { get; set; }
        public string Level1 { get; set; }

        public virtual ICollection<Course> CourseLevels { get; set; }
        public virtual ICollection<Course> CoursePrerequisiteNavigations { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
