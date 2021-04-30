using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Teachers.Queries.GetTeacherDetail
{
    public class GetTeacherDetailQueryHandler : IRequestHandler<GetTeacherDetailQuery, TeacherDetailVm>
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;

        public GetTeacherDetailQueryHandler(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherDetailVm> Handle(GetTeacherDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Teachers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Teacher), request.Id);
            }

            return _mapper.Map<TeacherDetailVm>(entity);
        }
    }
}