using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    public class AuthorizationController : AppControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost(Router.Authorization.AddRole)]
        public async Task<IActionResult> AddRole(AddRoleCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
