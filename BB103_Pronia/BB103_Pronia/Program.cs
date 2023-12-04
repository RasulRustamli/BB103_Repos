using BB103_Pronia.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddSession(p =>
{
    p.IdleTimeout=TimeSpan.FromSeconds(10);
});
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddScoped<LayoutService>();
var app = builder.Build();
app.UseSession();
app.UseStaticFiles();


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}"
    );



app.Run();
