using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Languages.Commands.UpsertLanguage
{
    public class UpsertLanguageCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public class UpsertLanguageCommandHandler : IRequestHandler<UpsertLanguageCommand, int>
        {
            private readonly ISchoolDbContext _context;

            public UpsertLanguageCommandHandler(ISchoolDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertLanguageCommand request, CancellationToken cancellationToken)
            {
                Language entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.Languages.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new Language();

                    _context.Languages.Add(entity);
                }

                entity.LanguageName = request.Name;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.LanguageId;
            }
        }
    }
}