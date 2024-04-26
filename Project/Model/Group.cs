
namespace Domain.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public Schedule Schedule { get; set; }
        public DateTime CreationDate { get; set; }
        public int ScheduleId { get; set; }
        public ICollection<Student>? Students { get; set; }
    }

}
