using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCourseDetail
{
    public class GetCourseDetailQueryHandler : IRequestHandler<GetCourseDetailQuery, CourseDetailVm>
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;

        public GetCourseDetailQueryHandler(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CourseDetailVm> Handle(GetCourseDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Courses
                .ProjectTo<CourseDetailVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.CourseId == request.Id, cancellationToken);

            if (vm == null)
            {
                throw new NotFoundException(nameof(Course), request.Id);
            }

            return vm;
        }
    }
}