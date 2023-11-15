using BB103_First_FrontoBack.Models;
using BB103_First_FrontoBack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BB103_First_FrontoBack.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            List<Slider> sliderList = new List<Slider>();

            sliderList.Add(new Slider()
            {
                Id = 4,
                Title ="Basliq 1",
                Description="Kara gunler",
                ImageUrl= "download.jpg"
            });
            sliderList.Add(new Slider()
            {
                Id = 5,
                Title = "Basliq 2",
                Description = "Qara gunler hele qabagdadir",
                ImageUrl = "images.jpg"
            });
            sliderList.Add(new Slider()
            {
                Id = 3,
                Title = "Basliq 3",
                Description = "Lorem ipsum",
                ImageUrl = "carousel-3.jpg"
            });
            sliderList.Add(new Slider()
            {
                Id = 1,
                Title = "Basliq 4",
                Description = "Lorem ipsum",
                ImageUrl = "carousel-3.jpg"
            });
            sliderList.Add(new Slider()
            {
                Id = 2,
                Title = "Basliq 5",
                Description = "Lorem ipsum",
                ImageUrl = "carousel-3.jpg"
            });


            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                Id = 1,
                Name="Kofta",
                Price=54.3,
                ImageUrl="adidasKofta.jpg"
            });
            products.Add(new Product()
            {
                Id = 2,
                Name = "Salvar",
                Price = 20,
                ImageUrl = "adidasSalvar.jpg"
            });
            products.Add(new Product()
            {
                Id = 3,
                Name = "Sepit",
                Price = 60,
                ImageUrl = "adidasSepit.jpg"
            });
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = sliderList.OrderBy(x => x.Id).Take(3).ToList();
            homeVM.Products=products;


            return View(homeVM);
        }

        
    }
}
