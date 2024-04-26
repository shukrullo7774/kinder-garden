using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Commands.Groups.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Group
            {
                Id = request.Id,
                GroupName = request.GroupName,
                CreationDate = DateTime.Today,
                Students = request.Students,

            };

            _context.Groups.Add(group);
            await _context.SaveChangeAsync(cancellationToken);
            
            return group.Id;
        }
    }
}
