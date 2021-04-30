using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest
    {
        public int Id { get; set; }
        
        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteStudentCommand>
        {
            private readonly ISchoolDbContext _context;
            private readonly IUserManager _userManager;
            private readonly ICurrentUserService _currentUser;

            public DeleteEmployeeCommandHandler(ISchoolDbContext context, IUserManager userManager, ICurrentUserService currentUser)
            {
                _context = context;
                _userManager = userManager;
                _currentUser = currentUser;
            }

            public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Students
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Student), request.Id);
                }

                if (entity.UserId == _currentUser.UserId)
                {
                    throw new BadRequestException("Students cannot delete their own account.");
                }

                if (entity.UserId != null)
                {
                    await _userManager.DeleteUserAsync(entity.UserId);
                }

                //исправить логику, это сработает только, если у студента нет никаких ассоциированных курсов или уровней по языкам

                _context.Students.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}