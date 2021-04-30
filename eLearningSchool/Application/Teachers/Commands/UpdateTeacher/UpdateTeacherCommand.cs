using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Teachers.Commands.CreateTeacher;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherCommand : IRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        
        public class Handler : IRequestHandler<UpdateTeacherCommand>
        {
            private readonly ISchoolDbContext _context;

            public Handler(ISchoolDbContext context, IMediator mediator)
            {
                _context = context;
            }
            
            public async Task<Unit> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Teachers
                    .SingleOrDefaultAsync(c => c.TeacherId == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Teacher), request.Id);
                }

                entity.Email = request.Email;
                entity.FirstName = request.FirstName;
                entity.LastName = request.LastName;
                entity.PhoneNumber = request.PhoneNumber;
                entity.Description = request.Description;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}