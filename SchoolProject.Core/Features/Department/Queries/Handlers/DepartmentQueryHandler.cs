using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler
        ,IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
            IDepartmentService departmentService, IStudentService studentService, IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var dept = await _departmentService.GetDepartmentByIdAsync(request.Id);
            if (dept == null) return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var mapper = _mapper.Map<GetDepartmentByIdResponse>(dept);

            //Pagination
            Expression<Func<Student, StudentResponse>> expression = 
                st => new StudentResponse(st.StudID, st.Localize(st.NameAr, st.NameEn));
            
            var studentQueryable = _studentService.GetStudentsByDepartmentIdQueryable(request.Id);
            
            var paginatedList = await studentQueryable.Select(expression)
                .ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = paginatedList;

            return Success(mapper);
        }
        #endregion
    }
}
