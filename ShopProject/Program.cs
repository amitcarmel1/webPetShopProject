using Microsoft.EntityFrameworkCore;
using ShopProject.Data;
using ShopProject.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository, MyRepository>();
builder.Services.AddDbContext<ShopContext>(options => options.UseSqlite("Data Source=c:\\temp2\\exercise.db"));
builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<ShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}");
});

app.Run();