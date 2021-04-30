using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand>
    {
        private readonly ISchoolDbContext _context;

        public DeleteTeacherCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Teachers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Teacher), request.Id);
            }

            var hasCourses = _context.Courses.Any(o => o.TeacherId == entity.TeacherId);
            if (hasCourses)
            {
                throw new DeleteFailureException(nameof(Teacher), request.Id, "There are existing courses associated with this customer.");
                //нужно изменить поведение на ClientSetNull
            }

            _context.Teachers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}