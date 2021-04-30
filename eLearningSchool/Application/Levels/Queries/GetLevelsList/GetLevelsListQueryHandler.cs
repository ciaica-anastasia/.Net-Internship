using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Levels.Queries.GetLevelsList
{
    public class GetLevelsListQueryHandler : IRequestHandler<GetLevelsListQuery, LevelsListVm>
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;

        public GetLevelsListQueryHandler(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LevelsListVm> Handle(GetLevelsListQuery request, CancellationToken cancellationToken)
        {
            var levels = await _context.Teachers
                .ProjectTo<LevelDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new LevelsListVm()
            {
                Levels = levels
            };

            return vm;
        }
    }
}