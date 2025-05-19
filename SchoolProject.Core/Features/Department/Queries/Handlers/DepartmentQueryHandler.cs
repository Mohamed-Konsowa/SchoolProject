using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler
        ,IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
            IDepartmentService departmentService, IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var dept = await _departmentService.GetDepartmentByIdAsync(request.Id);
            if (dept == null) return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var mapper = _mapper.Map<GetDepartmentByIdResponse>(dept);

            return Success(mapper);
        }
        #endregion
    }
}
