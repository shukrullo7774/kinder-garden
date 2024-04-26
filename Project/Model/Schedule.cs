namespace Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime {  get; set; }
        public DateTime EndTime {  get; set; }

        public Lesson Lesson { get; set; }
        public Group Groups { get; set; }
        public Teacher Teacher { get; set; }

    }
}
