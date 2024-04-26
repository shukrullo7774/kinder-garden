using Application.Interfaces;
using Application.Common.Exceptions;
using MediatR;

namespace Application.Features.Students.Update
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student  = await _context.Students.FindAsync(request.UserId, cancellationToken);
            if (student == null)
            {
                throw new NotFoundException(nameof(student), request.UserId);
            }

            student.Firstame = request.Firstame;
            student.Lastname = request.Lastname;
            student.PhoneNumber = request.PhoneNumber;
            student.Login = request.Login;
            student.Password = request.Password;

            _context.Students.Update(student);
            await _context.SaveChangeAsync(cancellationToken);

            return request.UserId;
        }

    }
}
