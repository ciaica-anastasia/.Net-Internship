using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Levels.Queries.GetLevelsList;
using Domain.Entities;
using MediatR;

namespace Application.Levels.Commands.UpsertLevel
{
    public class UpsertLevelCommand : IRequest<int>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        
        public class UpsertLevelCommandHandler : IRequestHandler<UpsertLevelCommand, int>
        {
            private readonly ISchoolDbContext _context;

            public UpsertLevelCommandHandler(ISchoolDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertLevelCommand request, CancellationToken cancellationToken)
            {
                Level entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.Levels.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new Level();

                    _context.Levels.Add(entity);
                }

                entity.LevelName = request.Name;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.LevelId;
            }
        }
    }
}