using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Teachers.Update
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teachers.FindAsync(request.UserId);
            if (teacher == null)
            {
                throw new NotFoundException(nameof(teacher), request.UserId);
            }
            teacher.UserId = request.UserId;
            teacher.Firstame = request.Firstame;
            teacher.Lastname = request.Lastname;
            teacher.PhoneNumber = request.PhoneNumber;
            teacher.Login = request.Login;
            teacher.Password = request.Password;

            _context.Teachers.Update(teacher);
            await _context.SaveChangeAsync(cancellationToken);
            
            return request.UserId;
        }
    }
}
