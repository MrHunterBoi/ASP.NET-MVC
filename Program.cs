using Microsoft.EntityFrameworkCore;
using ASP_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HospitalDBContext>(opt =>
    opt.UseSqlServer("Server=.;Database=Hospital;Trusted_Connection=true;TrustServerCertificate=true"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
