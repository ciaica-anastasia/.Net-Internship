using System.Collections.Generic;

namespace Application.Students.Queries.GetStudentsList
{
    public class StudentsListVm
    {
        public IList<StudentLookupDto> Students { get; set; }
    }
}