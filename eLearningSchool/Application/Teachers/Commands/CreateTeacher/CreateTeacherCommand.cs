using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommand : IRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        
        public class Handler : IRequestHandler<CreateTeacherCommand>
        {
            private readonly ISchoolDbContext _context;
            private readonly IMediator _mediator;

            public Handler(ISchoolDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            
            public async Task<Unit> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
            {
                var entity = new Teacher
                {
                    TeacherId = request.Id,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Description = request.Description
                };

                _context.Teachers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new TeacherCreated { TeacherId = entity.TeacherId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}