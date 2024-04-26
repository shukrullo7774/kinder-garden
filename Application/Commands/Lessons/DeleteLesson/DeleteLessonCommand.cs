using MediatR;

namespace Application.Features.Lessons.DeleteLesson
{
    public class DeleteLessonCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
    }
}
