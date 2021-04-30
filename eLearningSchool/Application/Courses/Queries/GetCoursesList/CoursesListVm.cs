using System.Collections.Generic;

namespace Application.Courses.Queries.GetCoursesList
{
    public class CoursesListVm
    {
        public IList<CourseDto> Courses { get; set; }
    }
}