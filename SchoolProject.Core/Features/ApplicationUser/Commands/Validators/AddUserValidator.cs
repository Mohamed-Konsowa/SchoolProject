using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AddUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _localizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(u => u.FullName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(u => u.Address)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(u => u.ConfirmPassword)
                .Equal(u => u.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);
        }

        public void ApplyCustomValidationRules()
        {

        }
    }
}
