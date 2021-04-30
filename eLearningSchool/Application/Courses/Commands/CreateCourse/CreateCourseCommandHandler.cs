using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, string>
    {
        private readonly ISchoolDbContext _context;

        public CreateCourseCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = new Course
            {
                Capacity = request.Capacity,
                Schedule = request.Schedule,
                LevelId = request.LevelId,
                TeacherId = request.TeacherId,
                LanguageId = request.LanguageId,
                Duration = request.Duration,
                Price = request.Price,
                Description = request.Description,
                PrerequisiteId = request.PrerequisiteId,
                AgeId = request.AgeId,
                Purpose = request.Purpose
            };

            _context.Courses.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.CourseId;
        }
    }
}