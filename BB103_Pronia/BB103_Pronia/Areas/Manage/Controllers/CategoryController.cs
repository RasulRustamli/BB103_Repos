using Microsoft.AspNetCore.Mvc;

namespace BB103_Pronia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {

        AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories =await _context.Categories.Include(p=>p.Products).ToListAsync();
            return View(categories);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Update(int id)
        {
            Category category = _context.Categories.Find(id);

            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category newCategory)
        {
            Category oldCategory=_context.Categories.Find(newCategory.Id);
            oldCategory.Name=newCategory.Name;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            Category category = _context.Categories.Find(Id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
