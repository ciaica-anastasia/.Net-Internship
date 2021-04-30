using MediatR;

namespace Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand : IRequest
    {
        public string Id { get; set; }
    }
}