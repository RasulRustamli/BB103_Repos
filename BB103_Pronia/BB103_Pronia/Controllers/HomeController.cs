
namespace BB103_Pronia.Controllers;

public class HomeController :Controller
{
    AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        HomeVm homeVm = new HomeVm()
        {
            Sliders = await _context.Sliders.OrderByDescending(s=>s.Id).Take(5).ToListAsync(),
            Products = await _context.Products.Include(p=>p.ProductImages).ToListAsync(),
        };



        return View(homeVm);
    }
}
