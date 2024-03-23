using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using movieSiteAgainAgain.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
	Options => { Options.UseSqlServer(builder.Configuration.GetConnectionString("MovieConnection"));
	}
);
builder.Services.AddSession(
	Options =>
	{
		Options.IdleTimeout=TimeSpan.FromHours(5);
		Options.Cookie.HttpOnly= true;	
		Options.Cookie.IsEssential= true;	
	}
	);


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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSession();
app.Run();
