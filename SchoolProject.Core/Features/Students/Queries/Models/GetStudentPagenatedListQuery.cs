using MediatR;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPagenatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public SudentOrderingEnum OrderBy { get; set; } 
        public string? Search { get; set; }
    }
}
