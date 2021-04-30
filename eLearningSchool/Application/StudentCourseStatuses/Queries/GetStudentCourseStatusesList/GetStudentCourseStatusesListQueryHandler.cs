using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.StudentCourseStatuses.Queries.GetStudentCourseStatusesList
{
    public class GetStudentCourseStatusesListQueryHandler : IRequestHandler<GetStudentCourseStatusesListQuery, StudentCourseStatusesListVm>
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentCourseStatusesListQueryHandler(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentCourseStatusesListVm> Handle(GetStudentCourseStatusesListQuery request, CancellationToken cancellationToken)
        {
            var statuses = await _context.StudentCourseStatuses
                .ProjectTo<StudentCourseStatusDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new StudentCourseStatusesListVm()
            {
                StudentCourseStatuses = statuses
            };

            return vm;
        }
    }
}