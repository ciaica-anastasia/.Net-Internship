using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Students.Queries.GetStudentDetail
{
    public class GetStudentDetailQuery : IRequest<StudentDetailVm>
    {
        public int Id { get; set; }

        public class GetStudentDetailQueryHandler : IRequestHandler<GetStudentDetailQuery, StudentDetailVm>
        {
            private readonly ISchoolDbContext _context;
            private readonly IMapper _mapper;

            public GetStudentDetailQueryHandler(ISchoolDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<StudentDetailVm> Handle(GetStudentDetailQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.Students
                    .Where(e => e.StudentId == request.Id)
                    .ProjectTo<StudentDetailVm>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}