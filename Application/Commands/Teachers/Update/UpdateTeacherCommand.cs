using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Teachers.Update
{
    public class UpdateTeacherCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Firstame { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
