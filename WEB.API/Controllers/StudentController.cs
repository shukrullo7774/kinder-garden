using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.GetStudentQueri;
using MediatR;
using Application.Features.Students.Create;
using AutoMapper;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public StudentController(IMediator mediator, IMapper mapper)
        {   
            _mapper = mapper;
            _mediator = mediator;
        }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetStudentInfo(int userId)
    {
        var query = new GetStudentInfoQuery(userId);
        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var studentId = await _mediator.Send(command);

            return Ok(studentId);
        }
    }
}



