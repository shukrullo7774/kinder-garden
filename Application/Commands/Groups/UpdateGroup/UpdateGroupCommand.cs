using Domain.Models;
using MediatR;

namespace Application.Commands.Groups.UpdateGroup
{
    public class UpdateGroupCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int GroupName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
