using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common;

namespace Store_Example.Application.Services.Users.Queries.GetUsers
{
	public class GetUsersService : IGetUsersService
	{
		private readonly IDatabaseContext _Context;

		public GetUsersService(IDatabaseContext context)
		{
			this._Context = context;
		}
		public ResultGetUsersDto Execute(RequestGetUsersdto request)
		{
			var usersQuery = _Context.users.AsQueryable();
			if (!string.IsNullOrEmpty(request.searchKey))
			{
				usersQuery.Where(x => x.FullName.Contains(request.searchKey) && x.Email.Contains(request.searchKey));
			}
			int rowsCount;
			var Users= usersQuery.ToPaged(request.Page, 20, out rowsCount).Select(x => new GetUsersDto
			{
				Email = x.Email,
				FullName = x.FullName,
				Id = x.Id,
				IsActive = x.IsActive
			}).ToList();
			return new ResultGetUsersDto { Users = Users, Rows = rowsCount };
		}
	}
}
