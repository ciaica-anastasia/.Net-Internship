using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Languages.Queries.GetLanguagesList
{
    public class GetLanguagesListQueryHandler : IRequestHandler<GetLanguagesListQuery, LanguagesListVm>
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;

        public GetLanguagesListQueryHandler(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LanguagesListVm> Handle(GetLanguagesListQuery request, CancellationToken cancellationToken)
        {
            var languages = await _context.Languages
                .ProjectTo<LanguageDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new LanguagesListVm
            {
                Languages = languages
            };

            return vm;
        }
    }
}