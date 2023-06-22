using Microsoft.EntityFrameworkCore;
using ProjectASP.NET.Data;
using ProjectASP.NET.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository, AniShopRepository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<AniShopContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
var app = builder.Build();
if (app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error/Index");
}
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AniShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
