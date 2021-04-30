using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Teachers.Queries.GetTeachersList
{
    public class GetTeachersListQueryHandler : IRequestHandler<GetTeachersListQuery, TeachersListVm>
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;

        public GetTeachersListQueryHandler(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeachersListVm> Handle(GetTeachersListQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _context.Teachers
                .ProjectTo<TeacherLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new TeachersListVm()
            {
                Teachers = teachers
            };

            return vm;
        }
    }
}