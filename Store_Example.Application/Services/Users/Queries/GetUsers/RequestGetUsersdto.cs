namespace Store_Example.Application.Services.Users.Queries.GetUsers
{
	public class RequestGetUsersdto
	{
		public string searchKey { get; set; }
		public int Page { get; set; } = 1;
	}
}
