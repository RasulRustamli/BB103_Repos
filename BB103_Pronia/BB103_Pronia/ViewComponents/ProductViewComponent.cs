namespace BB103_Pronia.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int key=1)
        {
            List<Product> products;
            switch (key)
            {
                case 1:products=await _context.Products.Where(p=>p.IsDeleted==false).Include(p=>p.ProductImages).OrderBy(p=>p.Name).Take(3).ToListAsync(); 
                    break;
                case 2: products=await _context.Products.Where(p => p.IsDeleted == false).Include(p=>p.ProductImages).OrderBy(p=>p.Price).Take(3).ToListAsync(); break;
                case 3: products = await _context.Products.Where(p => p.IsDeleted == false).Include(p => p.ProductImages).OrderByDescending(p => p.Id).Take(3).ToListAsync(); break;
                default:products = await _context.Products.Where(p => p.IsDeleted == false).Include(p => p.ProductImages).Take(3).ToListAsync();
                    break;
            }

            
            return View(products);
        }
    }
}
