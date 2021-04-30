using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand>
        {
            private readonly ISchoolDbContext _context;

            public DeleteLanguageCommandHandler(ISchoolDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Languages
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Language), request.Id);
                }

                _context.Languages.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}