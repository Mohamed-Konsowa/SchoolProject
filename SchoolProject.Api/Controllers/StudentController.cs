using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class StudentController : AppControllerBase
    {
        [HttpGet]
        [Route(Router.Student.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }

        [HttpGet]
        [Route(Router.Student.Paginated)]
        [AllowAnonymous]
        public async Task<IActionResult> GetStudentPaginatedList([FromQuery] GetStudentPagenatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route(Router.Student.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost]
        [Route(Router.Student.Create)]
        public async Task<IActionResult> Create([FromBody]AddStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.Student.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.Student.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteStudentCommand(id)));
        }
    }
}
