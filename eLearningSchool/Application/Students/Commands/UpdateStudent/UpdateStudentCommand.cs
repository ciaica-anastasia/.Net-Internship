using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public int? StudentOverallStatusId { get; set; }
        
        public class Handler : IRequestHandler<UpdateStudentCommand>
        {
            private readonly ISchoolDbContext _context;

            public Handler(ISchoolDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Students
                    .SingleOrDefaultAsync(c => c.StudentId == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Student), request.Id);
                }

                entity.FirstName = request.FirstName;
                entity.LastName = request.LastName;
                entity.PhoneNumber = request.PhoneNumber;
                entity.Email = request.Email;
                entity.BirthDate = request.BirthDate;
                entity.EnrollmentDate = request.EnrollmentDate;
                entity.StudentOverallStatusId = request.StudentOverallStatusId;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}