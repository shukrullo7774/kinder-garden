using MediatR;

namespace Application.Features.Students.Delete
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }
}
