using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
        IRequestHandler<SigninCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;

        #endregion

        #region Constructors
        public AuthenticationCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                            UserManager<User> userManager,
                                            SignInManager<User> signInManager,
                                            IAuthenticationService authenticationService
        ) 
            : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }


        #endregion

        #region Handle Functions


        public async Task<Response<string>> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            
            if( user == null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsNotExist]);
            
            var signinRes = _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signinRes.IsCompletedSuccessfully)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.PasswordNotCorrect]);

            var token = await _authenticationService.GetJWTToken(user);

            return Success(token);
        }

        #endregion
    }
}
