using Application.Interfaces;
using Application.Common.Exceptions;
using MediatR;

namespace Application.Commands.Lessons.UpdateLesson
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, int>
    {
        private readonly IApplicationDbContext _context;


        public UpdateLessonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FindAsync(request.Id, cancellationToken);
            if (lesson == null)
            {
                throw new NotFoundException(nameof(request.LessonName),request.Id);
            }

            lesson.LessonName = request.LessonName;
            lesson.Description = request.Description;

            _context.Lessons.Update(lesson);
            await _context.SaveChangeAsync(cancellationToken);

            return lesson.Id;
        }
    }
}

