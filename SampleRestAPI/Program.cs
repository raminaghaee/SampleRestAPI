using Microsoft.EntityFrameworkCore;
using SampleRestAPI.DbContext;
using SampleRestAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SampleRestDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SampleRestDb")));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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


//Automatic Migration
using (IServiceScope scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetService<SampleRestDbContext>();
    await context.Database.MigrateAsync();
}
    app.Run();
