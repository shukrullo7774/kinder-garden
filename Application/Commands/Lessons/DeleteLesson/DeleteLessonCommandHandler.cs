using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Lessons.DeleteLesson
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, int>
    {
        private readonly IApplicationDbContext _context;

        DeleteLessonCommandHandler(IApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FindAsync(request.Id, cancellationToken);
            if (lesson == null)
            {
                throw new NotFoundException(nameof(request), request.Id);
            }
            _context.Lessons.Remove(lesson);
            await _context.SaveChangeAsync(cancellationToken);
            return request.Id;
        }
    }
}
