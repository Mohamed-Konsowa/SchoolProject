using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolProject.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorizationController : AppControllerBase
    {
        [HttpPost(Router.Authorization.AddRole)]
        public async Task<IActionResult> AddRole([FromForm] AddRoleCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
        [HttpPost(Router.Authorization.Edit)]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.Authorization.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteRoleCommand(id));
            return NewResult(response);
        }
        [HttpGet(Router.Authorization.RoleList)]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await Mediator.Send(new GetRolesListQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "idالصلاحية عن طريق ال", OperationId = "RoleById")]
        [HttpGet(Router.Authorization.GetRoleById)]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetRoleByIdQuery() { Id = id });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = " ادارة صلاحيات المستخدمين", OperationId = "ManageUserRoles")]
        [HttpGet(Router.Authorization.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int userId)
        {
            var response = await Mediator.Send(new ManageUserRolesQuery() { UserId = userId });
            return NewResult(response);
        }
    }
}
