using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Students.Delete
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.UserId);
            if (student == null)
            {
                throw new NotFoundException(nameof(student), request.UserId);
            }
            _context.Students.Remove(student);
            await _context.SaveChangeAsync(cancellationToken);
            return request.UserId;
        }



    }
}
