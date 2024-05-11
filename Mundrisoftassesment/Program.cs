using Microsoft.EntityFrameworkCore;
using Mundrisoftassesment.Data;
using Mundrisoftassesment.Repositories;
using Mundrisoftassesment.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IUserServices, UserService>();
builder.Services.AddScoped<IEmployeeServices, EmployeeService>();
builder.Services.AddScoped<IDepartmentServices, DepartmentService>();
builder.Services.AddScoped<IDepartmentServices, DepartmentService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSession(session => {
    session.IdleTimeout = TimeSpan.FromMinutes(20);
    session.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpMethodOverride();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
