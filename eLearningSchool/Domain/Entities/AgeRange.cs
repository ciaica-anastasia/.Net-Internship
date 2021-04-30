using System.Collections.Generic;

namespace Domain.Entities
{
    public class AgeRange
    {
        public AgeRange()
        {
            Courses = new HashSet<Course>();
        }

        public int AgeId { get; set; }
        public string AgeRangeName { get; set; }

        public ICollection<Course> Courses { get; private set; }
    }
}
