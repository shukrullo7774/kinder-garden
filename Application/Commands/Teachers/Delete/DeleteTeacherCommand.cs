using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Teachers.Delete
{
    public class DeleteTeacherCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }
}
