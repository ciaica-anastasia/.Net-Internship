using MediatR;

namespace Application.Teachers.Queries.GetTeacherDetail
{
    public class GetTeacherDetailQuery : IRequest<TeacherDetailVm>
    {
        public int Id { get; set; }
    }
}