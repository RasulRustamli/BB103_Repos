using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            //string cookie = Request.Cookies["Name"];


            //if(cookie == null) return NotFound();
            //var session = HttpContext.Session.GetString("Name");
            


               
            Product product = await
                _context.Products
                .Include(c => c.Category)
                .Include(img => img.ProductImages)
                .Include(pt => pt.ProductTags).ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync(p => p.Id == id);
                
            if(product == null)
            {
                return NotFound();
            }
            DetailVm detailVm = new DetailVm()
            {
                Product = product,
                Products = _context.Products.Include(p => p.ProductImages).ToList()
            };
            return View(detailVm);
        }


        
        public IActionResult GetBasket()
        {
            var cookie = Request.Cookies["Basket"];

            return Content(cookie);
        }

    }
}
