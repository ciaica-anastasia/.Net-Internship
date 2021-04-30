using System.Collections.Generic;

namespace Application.Teachers.Queries.GetTeachersList
{
    public class TeachersListVm
    {
        public IList<TeacherLookupDto> Teachers { get; set; }
    }
}