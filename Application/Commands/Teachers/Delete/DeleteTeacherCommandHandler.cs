using Application.Interfaces;
using Application.Common.Exceptions;
using MediatR;

namespace Application.Features.Teachers.Delete
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teachers.FindAsync(request.UserId, cancellationToken);
            if (teacher == null)
            {
                throw new NotFoundException(nameof(teacher), request.UserId);
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangeAsync(cancellationToken);

            return teacher.UserId;

        }
    }
}
