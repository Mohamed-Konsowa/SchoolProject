using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> SignIn(SigninCommand request)
        {
            return NewResult(await Mediator.Send(request));
        }
    }
}
