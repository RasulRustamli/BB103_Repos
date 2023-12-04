using Newtonsoft.Json;

namespace BB103_Pronia.Services
{
    public class LayoutService
    {
        AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _http;

        public LayoutService(AppDbContext appDbContext, IHttpContextAccessor http)
        {
            _appDbContext = appDbContext;
            _http = http;
        }

        public async Task<Dictionary<string,string>> GetSetting()
        {
            var setting = await _appDbContext.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);
            return setting;
        }
        public List<BasketItemVm> GetBasket()
        {
            List<BasketItemVm> basket = new List<BasketItemVm>();
            var jsonBasket = _http.HttpContext.Request.Cookies["Basket"];
            if (jsonBasket!=null)
            {
                List<BasketCookieVm> basketCookie = JsonConvert.DeserializeObject<List<BasketCookieVm>>(jsonBasket);

                foreach (var item in basketCookie)
                {
                    Product product = _appDbContext.Products.Include(p => p.ProductImages.Where(pi => pi.IsPrime == true)).FirstOrDefault(p => p.Id == item.Id);

                    if (product == null)
                    {

                        continue;
                    }

                    basket.Add(new BasketItemVm()
                    {
                        Id = item.Id,
                        Name = product.Name,
                        Price = product.Price,
                        ImgUrl = product.ProductImages.FirstOrDefault().ImgUrl,
                        Count = item.Count
                    });
                }
            }
            return basket;
                
           
        }

    }
}
