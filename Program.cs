using Microsoft.EntityFrameworkCore;
using The_voice_of_geeta;
using The_voice_of_geeta.DATA;
using Microsoft.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("con"))
    );

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//  Admin Area Routing
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthorization();

app.Run();