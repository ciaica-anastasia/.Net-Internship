using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Teachers.Commands.CreateTeacher;
using Domain.Entities;
using MediatR;

namespace Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public int? StudentOverallStatusId { get; set; }

        public class Handler : IRequestHandler<CreateStudentCommand>
        {
            private readonly ISchoolDbContext _context;
            private readonly IMediator _mediator;

            public Handler(ISchoolDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            
            public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {
                var entity = new Student
                {
                    StudentId = request.Id,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    BirthDate = request.BirthDate,
                    EnrollmentDate = request.EnrollmentDate,
                    StudentOverallStatusId = request.StudentOverallStatusId
                };

                _context.Students.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new StudentCreated() { StudentId = entity.StudentId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}