using MediatR;

namespace Application.Commands.Lessons.UpdateLesson
{
    public class UpdateLessonCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
    }
}
