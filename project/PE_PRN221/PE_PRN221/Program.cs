using Microsoft.EntityFrameworkCore;
using Services;
using Services.Models;
using System.Runtime.Intrinsics.X86;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
/// This area call: Dependency Injection
//This is the place we connect with connection string
builder.Services.AddDbContext<ITDepartContext>(
options => options.UseSqlServer("name=ConnectionStrings:CarContractDBs"));
//we will 3 scope from 3 services
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<EnrollmentRepository>();
builder.Services.AddScoped<CourseRepository>();
//if you want to use Session , you need to call Session
builder.Services.AddSession();
///
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios,
app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
//Custome after call Session
app.UseSession();
//
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();