using Application.Interfaces;
using AutoMapper;
using MediatR;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetStudentQueri
{
    public class GetStudentInfoQueriHandler : IRequestHandler<GetStudentInfoQuery, GetStudentInfoVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentInfoQueriHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetStudentInfoVm> Handle(GetStudentInfoQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(student => student.UserId == request.UserId, cancellationToken);
            if (student == null || student.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(student), request.UserId);
            }
            return _mapper.Map<GetStudentInfoVm>(student);  
        }
        
    }
}
