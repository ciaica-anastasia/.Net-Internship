using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.StudentCourseStatuses.Commands.DeleteStudentCourseStatus
{
    public class DeleteStudentCourseStatusCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteStudentCourseStatusCommandHandler : IRequestHandler<DeleteStudentCourseStatusCommand>
        {
            private readonly ISchoolDbContext _context;

            public DeleteStudentCourseStatusCommandHandler(ISchoolDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteStudentCourseStatusCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.StudentCourseStatuses
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(StudentCourseStatus), request.Id);
                }

                _context.StudentCourseStatuses.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}