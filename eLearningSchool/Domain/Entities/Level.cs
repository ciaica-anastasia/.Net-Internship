using System.Collections.Generic;

namespace Domain.Entities
{
    public class Level
    {
        public Level()
        {
            CourseLevels = new HashSet<Course>();
            CoursePrerequisiteLevels = new HashSet<Course>();
            StudentLevels = new HashSet<StudentLevel>();
        }

        public int LevelId { get; set; }
        public string LevelName { get; set; }

        public ICollection<Course> CourseLevels { get; private set; }
        public ICollection<Course> CoursePrerequisiteLevels { get; private set; }
        public ICollection<StudentLevel> StudentLevels { get; private set; }
    }
}
