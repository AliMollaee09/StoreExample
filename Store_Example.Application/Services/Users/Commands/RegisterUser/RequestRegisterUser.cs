namespace Store_Example.Application.Services.Users.Commands.RegisterUser
{
	public class RequestRegisterUser
	{
		public string FullName { get; set; }
		public string Email { get; set; }

		public string Password { get; set; }
		public string RePasword { get; set; }
		public List<RolesInRegisterUserDto> Roles { get; set; }


	}
}
