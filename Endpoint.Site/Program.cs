using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Application.Interfaces.Facad;
using Store_Example.Application.Services.Products.Facad;
using Store_Example.Application.Services.Users.Commands.DeleteUser;
using Store_Example.Application.Services.Users.Commands.EditUser;
using Store_Example.Application.Services.Users.Commands.RegisterUser;
using Store_Example.Application.Services.Users.Commands.UserStatusChange;
using Store_Example.Application.Services.Users.Queries.GetRoles;
using Store_Example.Application.Services.Users.Queries.GetUsers;
using Store_Example.Persistance.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRoles, GetRoles>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<IDeleteUserService, DeleteUserService>();
builder.Services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
builder.Services.AddScoped<IProductFacad, ProductFacad>();

string connectionString = @"Data Source=.;Initial Catalog=Store;Integrated Security=true; TrustServerCertificate=True;";

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DatabaseContext>(option=>option.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
