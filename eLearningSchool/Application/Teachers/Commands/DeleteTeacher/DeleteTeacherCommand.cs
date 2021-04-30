using MediatR;

namespace Application.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand : IRequest
    {
        public int Id { get; set; }
    }
}