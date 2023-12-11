using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BB103_Pronia.Controllers
{
    
    public class CartController : Controller
    {
        AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CartController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
           

            List<BasketItemVm> basketItems = new List<BasketItemVm>();
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                List<BasketItem> userBasket = await _context.BasketItems
                    .Where(b=>b.AppUserId==user.Id && b.OrderId == null)
                    .Include(b=>b.Product)
                    .ThenInclude(p=>p.ProductImages
                    .Where(pi=>pi.IsPrime==true)).ToListAsync();
                foreach(var item in userBasket)
                {
                    basketItems.Add(new BasketItemVm()
                    {
                        Price = item.Price,
                        Count=item.Count,
                        ImgUrl=item.Product.ProductImages.FirstOrDefault().ImgUrl,
                        Name=item.Product.Name
                    });
                }

            }
            else
            {


                List<BasketCookieVm> basketCookies = new List<BasketCookieVm>();
                if (Request.Cookies["Basket"] != null)
                {
                    basketCookies = JsonConvert.DeserializeObject<List<BasketCookieVm>>(Request.Cookies["Basket"]);
                    foreach (var item in basketCookies)
                    {
                        Product product = _context.Products.Where(p => p.IsDeleted == false).Include(p => p.ProductImages.Where(pi => pi.IsPrime == true)).FirstOrDefault(p => p.Id == item.Id);

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

            }
                return View(basketItems);
            
            
        }
        public async Task<IActionResult> AddBasket(int id)
        {
            var product = _context.Products.Where(p => p.IsDeleted == false).FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            if(User.Identity.IsAuthenticated)
            {
                AppUser user=await _userManager.FindByNameAsync(User.Identity.Name);
                BasketItem existItem = await _context.BasketItems
                    .FirstOrDefaultAsync(p => p.AppUserId == user.Id && p.ProductId == product.Id && p.OrderId == null);
                if(existItem!=null)
                {
                    existItem.Count++;
                }
                else
                {
                    BasketItem basketItem = new BasketItem()
                    {
                        AppUser = user,
                        Product = product,
                        Count = 1,
                        Price = product.Price,

                    };
                    _context.BasketItems.Add(basketItem);

                }
               await _context.SaveChangesAsync();
               

            }
            else
            {
                List<BasketCookieVm> basket;
                if (Request.Cookies["Basket"] == null)
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
                    if (existBasket != null)
                    {
                        existBasket.Count += 1;
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
                var json = JsonConvert.SerializeObject(basket);
                Response.Cookies.Append("Basket", json);
            }




            

            return RedirectToAction(nameof(Index), "Home");
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            OrderVm orderVm = new OrderVm();
            orderVm.BasketItems = await _context.BasketItems
                .Where(b => b.AppUserId == user.Id&&b.OrderId==null).Include(b=>b.Product).ToListAsync();
            return View(orderVm);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Checkout(OrderVm orderVm)
        {
           AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
           if(!ModelState.IsValid)
            {
                orderVm.BasketItems = await _context.BasketItems
             .Where(b => b.AppUserId == user.Id && b.OrderId == null).Include(b => b.Product).ToListAsync();
                ModelState.AddModelError("Address", "Addresi mutleq doldurun");
                return View(orderVm);
            }
           var userBasketItems=await _context.BasketItems
             .Where(b => b.AppUserId == user.Id && b.OrderId == null).Include(b => b.Product).ToListAsync();
            double TotalPrice = 0;
            for(int i=0;i<userBasketItems.Count;i++)
            {
                TotalPrice+=userBasketItems[i].Price*userBasketItems[i].Count;
            }
            Order order = new Order()
            {
                BasketItems = userBasketItems,
                Address = orderVm.Address,
                AppUser = user,
                CreateDate = DateTime.Now,
                TotalPrice = TotalPrice
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();




            return RedirectToAction(nameof(Index),"Home");
        }

    }
}
