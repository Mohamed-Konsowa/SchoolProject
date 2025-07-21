using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	public class ApplicationUserController : AppControllerBase
	{
		[HttpPost(Router.ApplicationUser.Create)]
		public async Task<IActionResult> Create([FromBody] AddUserCommand request)
		{
			return NewResult(await Mediator.Send(request));
		}

		[HttpGet(Router.ApplicationUser.Paginated)]
		public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery request)
		{
			var response = await Mediator.Send(request);
			return Ok(response);
		}

		[HttpGet(Router.ApplicationUser.GetById)]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			return NewResult(await Mediator.Send(new GetUserByIdQuery(id)));
		}
	}
}
