using Application.Interfaces;
using MediatR;
using Domain.Models;

namespace Application.Commands.Lessons.CreateLesson
{
    public class CreateLessonsCommandHandler : IRequestHandler<CreateLessonCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateLessonsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLessonCommand request, CancellationToken cancellationtoken)
        {
            var lessons = new Lesson
            {
                LessonName = request.LessonName,
                Description = request.Description,
                Category = (Domain.Enums.Category)request.Category,
            };

            _context.Lessons.Add(lessons);
            await _context.SaveChangeAsync(cancellationtoken);
            return lessons.Id;
        }
    }
}
