using BB103_First_FrontoBack.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer("Server=DESKTOP-FHK353D;Database=BB103_Multi_Shop;Trusted_connection=true;Integrated security=true;Encrypt=false");
});


var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.UseStaticFiles();



app.Run();
