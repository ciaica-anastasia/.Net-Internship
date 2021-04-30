using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseProjecteLearningSchool.Model
{
    public partial class AgeRange
    {
        public AgeRange()
        {
            Courses = new HashSet<Course>();
        }

        public int AgeId { get; set; }
        public string AgeRange1 { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
