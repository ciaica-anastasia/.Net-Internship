using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly ISchoolDbContext _context;

        public DeleteCourseCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Courses.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Course), request.Id);
            }

            var hasStudents = _context.StudentCourseRelations.Any(od => od.CourseId.Equals(entity.CourseId));
            if (hasStudents)
            {
                throw new DeleteFailureException(nameof(Course), request.Id, "There are existing students associated with this course.");
            }

            _context.Courses.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}