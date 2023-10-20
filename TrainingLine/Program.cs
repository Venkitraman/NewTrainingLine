using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainingLine.Models;
using TrainingLine.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BookDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
//Configure the Sql Server Database ConnectionStrings
builder.Services.AddDbContext<BookDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
