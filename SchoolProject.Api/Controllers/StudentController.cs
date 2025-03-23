using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route(Router.Student.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }

        [HttpGet]
        [Route(Router.Student.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        [Route(Router.Student.Create)]
        public async Task<IActionResult> Create([FromBody]AddStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
