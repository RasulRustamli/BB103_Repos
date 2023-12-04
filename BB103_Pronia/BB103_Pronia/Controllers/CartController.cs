using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BB103_Pronia.Controllers
{
    public class CartController : Controller
    {
        AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           

                List<BasketItemVm> basketItems = new List<BasketItemVm>();
            List<BasketCookieVm> basketCookies=new List<BasketCookieVm>();
                if (Request.Cookies["Basket"] != null)
                {
                basketCookies= JsonConvert.DeserializeObject<List<BasketCookieVm>>(Request.Cookies["Basket"]);
                foreach (var item in basketCookies)
                    {
                        Product product = _context.Products.Include(p => p.ProductImages.Where(pi => pi.IsPrime == true)).FirstOrDefault(p => p.Id == item.Id);

                        if (product == null)
                        {
                           
                            continue;
                        }

                        basketItems.Add(new BasketItemVm()
                        {
                            Id = item.Id,
                            Name = product.Name,
                            Price = product.Price,
                            ImgUrl = product.ProductImages.FirstOrDefault().ImgUrl,
                            Count = item.Count
                        });
                    }
                }
            
                Response.Cookies.Append("Basket", JsonConvert.SerializeObject(basketCookies));


                return View(basketItems);
            
            
        }
    }
}
