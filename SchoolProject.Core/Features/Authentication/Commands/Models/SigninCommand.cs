using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class SigninCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
