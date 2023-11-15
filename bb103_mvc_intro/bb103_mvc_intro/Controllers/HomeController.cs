using bb103_mvc_intro.Models;
using Microsoft.AspNetCore.Mvc;

namespace bb103_mvc_intro.Controllers
{
    public class HomeController : Controller
    {
       public IActionResult Index()
        {

            List<Student> students = new List<Student>();
            students.Add(new Student()
            {
                Id=1,
                Name="Qemze"
            });
            students.Add(new Student()
            {
                Id = 2,
                Name = "Meryem"
            });
            students.Add(new Student()
            {
                Id = 3,
                Name = "Narmin"
            });

            


            ViewBag.data = "Hello ViewBag";
            ViewData["data"]="Hello viewData";
            TempData["data"]= "Hello TempData";
            return RedirectToAction("About");
        }

        public IActionResult About()
        {

            return View();


        }
        



    }
}
