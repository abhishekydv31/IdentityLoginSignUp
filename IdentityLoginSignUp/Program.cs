using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityLoginSignUp.Areas.Identity.Data;
using IdentityLoginSignUp.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using FluentAssertions.Common;
using IdentityLoginSignUp.Interfaces;
using IdentityLoginSignUp.Repositories;
using Microsoft.DotNet.Scaffolding.Shared;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDBContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityLoginSignUpUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//var  provider=builder.Services.BuildServiceProvider();
//var config = provider.GetRequiredService<IConfiguration>();
//builder.Services.AddDbContext<StudentDBContext>(item => item.UseSqlServer(config.GetConnectionString("")));

//Services.AddHttpContextAccessor();
builder.Services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<IRazorRenderService, RazorRenderService>();
builder.Services.AddHttpContextAccessor();


var provider = builder.Services.BuildServiceProvider();
var config = provider.GetService<IConfiguration>();


builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(
        config.GetConnectionString("ApplicationDBContextConnection"),
        b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));
#region Repositories
builder.Services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
builder.Services.AddTransient<IStudentRepositoryAsync, StudentRepositoryAsync>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
#endregion
builder.Services.AddSession();

var app = builder.Build();
app.UseSession();

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
app.MapRazorPages();
app.Run();
