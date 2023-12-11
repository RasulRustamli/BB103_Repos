
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
        //Response.Cookies.Append("Name", "Qemze");

        //HttpContext.Session.SetString("Name", "Meryem");

        HomeVm homeVm = new HomeVm()
        {
            Sliders = await _context.Sliders.OrderByDescending(s=>s.Id).Take(5).ToListAsync(),
            Products = await _context.Products.Where(p => p.IsDeleted == false).Include(p=>p.ProductImages).ToListAsync(),
        };



        return View(homeVm);
    }
}
