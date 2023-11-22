using Microsoft.AspNetCore.Mvc;

namespace BB103_Pronia.Controllers
{
    public class ShopController : Controller
    {
        AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Detail(int id)
        {
            Product product = await
                _context.Products
                .Include(c => c.Category)
                .Include(img => img.ProductImages)
                .Include(pt => pt.ProductTags).ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync(p => p.Id == id);
                

            




            return View(product);
        }
    }
}
