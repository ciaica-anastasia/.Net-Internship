using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Students.Queries.GetStudentsList
{
    public class GetStudentsListQuery : IRequest<StudentsListVm>
    {
        public class GetStudentsListQueryHandler : IRequestHandler<GetStudentsListQuery, StudentsListVm>
        {
            private readonly ISchoolDbContext _context;
            private readonly IMapper _mapper;

            public GetStudentsListQueryHandler(ISchoolDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<StudentsListVm> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
            {
                var students = await _context.Students
                    .ProjectTo<StudentLookupDto>(_mapper.ConfigurationProvider)
                    .OrderBy(e => e.Name)
                    .ToListAsync(cancellationToken);

                var vm = new StudentsListVm()
                {
                    Students = students
                };

                return vm;
            }
        }
    }
}