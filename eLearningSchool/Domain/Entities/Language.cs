using System.Collections.Generic;

namespace Domain.Entities
{
    public class Language
    {
        public Language()
        {
            Courses = new HashSet<Course>();
            StudentLevels = new HashSet<StudentLevel>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public ICollection<Course> Courses { get; private set; }
        public ICollection<StudentLevel> StudentLevels { get; private set; }
    }
}