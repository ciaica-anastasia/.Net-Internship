using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Teacher : AuditableEntity
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }

        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public ICollection<Course> Courses { get; private set; }
    }
}
