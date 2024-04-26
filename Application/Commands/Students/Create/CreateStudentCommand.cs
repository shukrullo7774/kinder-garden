using MediatR;

namespace Application.Features.Students.Create
{
    public class CreateStudentCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Firstame { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
