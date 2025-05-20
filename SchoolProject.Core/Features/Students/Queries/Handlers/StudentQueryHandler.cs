using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler
                                     , IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>
                                     , IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>
                                     , IRequestHandler<GetStudentPagenatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = stringLocalizer;
        }
        #endregion 
        #region Handle Functions
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            var result = Success(studentListMapper);
            result.Meta = new { Count = studentListMapper.Count() };
            return result;
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIDWithIncludeAsync(request.Id);
            if (student == null) return NotFound<GetSingleStudentResponse>(_localizer[SharedResourcesKeys.NotFound]);
            var studentMapper = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(studentMapper);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPagenatedListQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Student, GetStudentPaginatedListResponse>> expression = 
            //    (s) => new GetStudentPaginatedListResponse(s.StudID, s.Localize(s.NameAr, s.NameEn), s.Address, s.Department.Localize(s.Department.DNameAr, s.Department.DNameEn));
            //var filteredQuery = _studentService.FilterStudentPaginatedQueryable(request.OrderBy, request.Search);
            //var paginated = await filteredQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var filteredQuery = _studentService.FilterStudentPaginatedQueryable(request.OrderBy, request.Search);
            var paginated = await _mapper.ProjectTo<GetStudentPaginatedListResponse>(filteredQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);


            paginated.Meta = new { Count = paginated.Data.Count()};
            return paginated;
        }
        #endregion

    }
}
