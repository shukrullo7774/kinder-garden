using Domain.Models;
using MediatR;

namespace Application.Commands.Groups.CreateGroup
{
    public class CreateGroupCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}