using MediatR;

namespace Application.Commands.Lessons.CreateLesson
{
    public class CreateLessonCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
    }
}
