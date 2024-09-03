using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



//auth servisi benim eklediðim
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
config.Filters.Add(new AuthorizeFilter(policy));
});



builder.Services.AddSession();

builder.Services.AddMvc();
//Auth olmadan yaptýðým iþlemlerde beni login urle geri döndürmesi için eklediðim metot
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => { x.LoginPath = "/Login/Index"; }
    );

builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<AppUser, AppRole>()
	.AddEntityFrameworkStores<Context>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Home/Error");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseSession();

app.UseRouting();

app.UseAuthorization();


//app.MapControllerRoute(
//    name: "Admin",
//    pattern: "{area:exists}/{controller=Chart}/{action=CategoryChart}/{id?}");


app.MapControllerRoute(
  name: "Admin",
  pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}");



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
