using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.Students.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                UserId = request.UserId,
                Firstame = request.Firstame,
                Lastname = request.Lastname,
                PhoneNumber = request.PhoneNumber,
                Login = request.Login,
                Password = request.Password,
            };

            _context.Students.Add(student);
            await _context.SaveChangeAsync(cancellationToken);

            return student.UserId;
        }
    }
}
