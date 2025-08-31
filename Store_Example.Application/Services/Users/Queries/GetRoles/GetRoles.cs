using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Users.Queries.GetRoles
{
	public class GetRoles : IGetRoles
	{
		private readonly IDatabaseContext _context;

		public GetRoles(IDatabaseContext context)
		{
			_context = context;
		}

		public ResultDto<List<GetRolesDto>> Execute()
		{
			var roles = _context.Roles.Select(x => new GetRolesDto
			{
				RoleId = x.Id,
				Name = x.Name
			}).ToList();
			return new ResultDto<List<GetRolesDto>>
			{
				Data = roles,
				Message = "موفقیت آمیز بود",
				IsSuccess = true
			};
		}
	}
}
