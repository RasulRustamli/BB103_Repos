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


        public IActionResult AddBasket(int id)
        {
            var product = _context.Products.FirstOrDefault(p=>p.Id==id);
            if (product == null) return NotFound();
            List<BasketCookieVm> basket;
            if(Request.Cookies["Basket"]==null)
            {
                BasketCookieVm basketCookieVm = new BasketCookieVm()
                {
                    Id = id,
                    Count = 1
                };
                basket = new List<BasketCookieVm>();
                basket.Add(basketCookieVm);
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketCookieVm>>(Request.Cookies["Basket"]);
                var existBasket = basket.FirstOrDefault(p => p.Id == id);
                if(existBasket!=null)
                {
                    existBasket.Count+=1;
                }
                else
                {
                    BasketCookieVm basketCookieVm = new BasketCookieVm()
                    {
                        Id = id,
                        Count = 1
                    };
                    basket.Add(basketCookieVm);
                }
            }
            var json=JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket",json);

            return RedirectToAction(nameof(Index), "Home");
        }
        public IActionResult GetBasket()
        {
            var cookie = Request.Cookies["Basket"];

            return Content(cookie);
        }

    }
}
