namespace Domain.Models
{
    public class Student : User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Grades { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
