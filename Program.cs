using Microsoft.EntityFrameworkCore;
using ASP_API;
using Microsoft.AspNetCore.Identity;
using ASP.NET_MVC.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UserDbContextConnection") ?? throw new InvalidOperationException("Connection string 'UserDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddRazorPages();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HospitalDBContext>(opt =>
    opt.UseSqlServer("Server=.;Database=Hospital;Trusted_Connection=true;TrustServerCertificate=true"));

builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDefaultIdentity<Users>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<UserDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 1;
});
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
