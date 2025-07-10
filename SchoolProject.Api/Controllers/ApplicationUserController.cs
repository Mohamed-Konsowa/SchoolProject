using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	public class ApplicationUserController : AppControllerBase
	{
		[HttpPost(Router.ApplicationUser.Create)]
		public async Task<IActionResult> GetDepartmentById([FromBody] AddUserCommand request)
		{
			return NewResult(await Mediator.Send(request));
		}
	}
}
