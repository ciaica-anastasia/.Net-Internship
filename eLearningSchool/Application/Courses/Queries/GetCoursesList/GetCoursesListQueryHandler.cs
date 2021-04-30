using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCoursesList
{
    public class GetCoursesListQueryHandler : IRequestHandler<GetCoursesListQuery, CoursesListVm>
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;

        public GetCoursesListQueryHandler(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CoursesListVm> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Courses
                .ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.LevelName)
                .ToListAsync(cancellationToken);

            var vm = new CoursesListVm
            {
                Courses = products,
            };

            return vm;
        }
    }
}