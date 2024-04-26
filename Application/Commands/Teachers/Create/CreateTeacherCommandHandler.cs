using Application.Interfaces;
using MediatR;
using Domain.Models;

namespace Application.Features.Teachers.Create
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }   

        public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = new Teacher
            {
                Firstame = request.Firstame,
                Lastname = request.Lastname,
                PhoneNumber = request.PhoneNumber,
                Login = request.Login,
                Password = request.Password,
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangeAsync(cancellationToken);

            return teacher.UserId;
        }
    }
}
