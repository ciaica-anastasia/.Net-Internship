using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseProjecteLearningSchool.Model
{
    public partial class Language
    {
        public Language()
        {
            Courses = new HashSet<Course>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
