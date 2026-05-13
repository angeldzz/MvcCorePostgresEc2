using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEc2.Data;
using MvcCorePostgresEc2.Repositories;

var builder = WebApplication.CreateBuilder(args);

string conectionString = builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddTransient<RepositoryDepartamentos>();
builder.Services.AddDbContext<HospitalContext>(options => options.UseNpgsql(conectionString));

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

app.Run();
