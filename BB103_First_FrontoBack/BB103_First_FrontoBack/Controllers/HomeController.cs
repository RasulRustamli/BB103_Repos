using BB103_First_FrontoBack.DAL;
using BB103_First_FrontoBack.Models;
using BB103_First_FrontoBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BB103_First_FrontoBack.Controllers
{
    public class HomeController:Controller
    {
        AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        

        public IActionResult Index()
        {
           
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = _context.Sliders.Take(3).ToList();
            homeVM.Products= _context.Products.Include(p=>p.Category).ToList();
            homeVM.Categories = _context.Categories.Include(c=>c.Products).ToList();
            return View(homeVM);
        }


        public IActionResult Detail(int? id)
        {
            if (id == null) return BadRequest();
            
            Product product=_context.Products.FirstOrDefault(p=> p.Id == id);

            if (product == null) return NotFound();

            return View(product);
        }

        
    }
}
