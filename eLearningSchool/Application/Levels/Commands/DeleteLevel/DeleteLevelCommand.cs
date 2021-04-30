using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Levels.Commands.DeleteLevel
{
    public class DeleteLevelCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteLevelCommand>
        {
            private readonly ISchoolDbContext _context;

            public DeleteCategoryCommandHandler(ISchoolDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteLevelCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Levels
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Level), request.Id);
                }

                _context.Levels.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}