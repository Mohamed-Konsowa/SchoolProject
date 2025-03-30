using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Constructors
        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MaximumLength(100).WithMessage("Name max length is 100");

            RuleFor(s => s.Address)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null")
                .MaximumLength(100).WithMessage("{PropertyName} max length is 100");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(s => s.Name)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExistsAsync(Key))
                .WithMessage("Name is Exist");
        }
        #endregion
    }
}
