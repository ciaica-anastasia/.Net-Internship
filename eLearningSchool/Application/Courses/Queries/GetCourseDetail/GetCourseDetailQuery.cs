using MediatR;

namespace Application.Courses.Queries.GetCourseDetail
{
    public class GetCourseDetailQuery : IRequest<CourseDetailVm>
    {
        public string Id { get; set; }
    }
}