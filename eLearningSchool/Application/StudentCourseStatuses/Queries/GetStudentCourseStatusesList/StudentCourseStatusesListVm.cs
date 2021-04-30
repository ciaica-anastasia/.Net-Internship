using System.Collections.Generic;

namespace Application.StudentCourseStatuses.Queries.GetStudentCourseStatusesList
{
    public class StudentCourseStatusesListVm
    {
        public IList<StudentCourseStatusDto> StudentCourseStatuses { get; set; }
    }
}