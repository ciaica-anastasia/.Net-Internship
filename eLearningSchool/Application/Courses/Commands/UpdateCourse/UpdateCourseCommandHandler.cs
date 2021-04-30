using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly ISchoolDbContext _context;

        public UpdateCourseCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Courses.FindAsync(request.CourseId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Course), request.CourseId);
            }

            entity.CourseId = request.CourseId;
            entity.Capacity = request.Capacity;
            entity.Schedule = request.Schedule;
            entity.LevelId = request.LevelId;
            entity.TeacherId = request.TeacherId;
            entity.LanguageId = request.LanguageId;
            entity.Duration = request.Duration;
            entity.Price = request.Price;
            entity.Description = request.Description;
            entity.PrerequisiteId = request.PrerequisiteId;
            entity.AgeId = request.AgeId;
            entity.Purpose = request.Purpose;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}