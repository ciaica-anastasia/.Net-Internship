using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.StudentCourseStatuses.Queries.GetStudentCourseStatusesList;
using Domain.Entities;
using MediatR;

namespace Application.StudentCourseStatuses.Commands.UpsertStudentCourseStatus
{
    public class UpsertStudentCourseStatusCommand : IRequest<int>
    {
        public int? Id { get; set; }
        public string StatusName { get; set; }
        
        public class UpsertStudentCourseStatusCommandHandler : IRequestHandler<UpsertStudentCourseStatusCommand, int>
        {
            private readonly ISchoolDbContext _context;

            public UpsertStudentCourseStatusCommandHandler(ISchoolDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertStudentCourseStatusCommand request, CancellationToken cancellationToken)
            {
                StudentCourseStatus entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.StudentCourseStatuses.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new StudentCourseStatus();

                    _context.StudentCourseStatuses.Add(entity);
                }
                
                entity.StudentCourseStatusName = request.StatusName;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.StudentCourseStatusId;
            }
        }
    }
}