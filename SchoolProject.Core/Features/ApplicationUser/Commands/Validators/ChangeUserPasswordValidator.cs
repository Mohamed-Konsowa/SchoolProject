using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validators
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        public ChangeUserPasswordValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidation();
        }

        public void ApplyValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(u => u.CurrentPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(u => u.NewPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(u => u.ConfirmPassword)
                .Equal(u => u.NewPassword).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);
        }
    }
}
