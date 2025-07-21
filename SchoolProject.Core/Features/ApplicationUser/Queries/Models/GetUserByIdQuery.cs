using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Queries.Results;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Models
{
	public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
	{
		public int UserId { get; set; }

		public GetUserByIdQuery(int userId)
		{
			UserId = userId;
		}
	}
}
