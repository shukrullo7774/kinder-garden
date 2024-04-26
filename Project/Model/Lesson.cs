using Domain.Enums; 


namespace Domain.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public Category Category;
        public string LessonName { get; set; }
        public string Description { get; set; }
        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }
    }
}
