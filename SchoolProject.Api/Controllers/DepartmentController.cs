using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.Department.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromQuery]GetDepartmentByIdQuery request)
        {
            return NewResult(await Mediator.Send(request));
        }
    }
}
