using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseProjecteLearningSchool.Model
{
    public class StudentOverallStatus
    {
        public StudentOverallStatus()
        {
            Students = new HashSet<Student>();
        }

        public int StudentOverallStatusId { get; set; }
        public string StudentOverallStatus1 { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
