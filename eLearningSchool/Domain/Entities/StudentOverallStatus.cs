using System.Collections.Generic;

namespace Domain.Entities
{
    public class StudentOverallStatus
    {
        public StudentOverallStatus()
        {
            Students = new HashSet<Student>();
        }

        public int StudentOverallStatusId { get; set; }
        public string StudentOverallStatusName { get; set; }

        public ICollection<Student> Students { get; private set; }
    }
}
