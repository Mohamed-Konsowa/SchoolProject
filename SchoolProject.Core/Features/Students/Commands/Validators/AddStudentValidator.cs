﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public AddStudentValidator(IStudentService studentService
            , IDepartmentService departmentService
            , IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _localizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(s => s.NameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);
            
            RuleFor(s => s.NameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(s => s.Address)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(s => s.DepartmentId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(s => s.NameAr)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameArExistsAsync(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            
            RuleFor(s => s.NameEn)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameEnExistsAsync(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(s => s.DepartmentId)
                .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExistsAsync(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion
    }
}
