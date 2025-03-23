using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Queries.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("/Student/List")]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }

        [HttpGet]
        [Route("/Student/getById/{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        }
    }
}
