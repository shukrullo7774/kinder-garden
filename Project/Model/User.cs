namespace Domain.Models
{
    abstract public class User
    {
        public int UserId { get; set; }
        public string Firstame { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
  
    }
}
