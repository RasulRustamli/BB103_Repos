using BB103_Pronia.Helpers;

namespace BB103_Pronia.Areas.Manage.Controllers
{

    [Area("manage")]
    public class SliderController:Controller
    {
        AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliderList = await _db.Sliders.ToListAsync();
            return View(sliderList);
        }
        //HTTPGET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider == null)
            {
                return BadRequest();
            }
            if (!slider.ImageFile.CheckContent("image/"))
            { 
                ModelState.AddModelError("ImageFile", "Duzgun format daxil edin");

                return View();
            }
            if(!slider.ImageFile.CheckLenght(20000))
            {
                ModelState.AddModelError("ImageFile", "Maksimum 2mb olcude sekil yukleye bilersiz");
                return View();
            }
            //string filname = slider.ImageFile.FileName;
            //if(filname.Length>64)
            //{

            //    filname=filname.Substring(filname.Length-64,64);
            //}

            //filname = Guid.NewGuid().ToString() + filname;
            ////string path = @"C:\Users\rasul\OneDrive\Masaüstü\BB103_Pronia\BB103_Pronia\wwwroot\UploadImages\SliderImg\" + filname;
            //string path = _env.WebRootPath + @"\Upload\SliderImage\" + filname;


            //using(FileStream stream = new FileStream(path, FileMode.Create))
            //{
            //    slider.ImageFile.CopyTo(stream);
            //}
            //slider.ImgUrl = filname;



            slider.ImgUrl = slider.ImageFile.UploadFile(_env.WebRootPath, @"\Upload\SliderImage\");

            if (!ModelState.IsValid)
            {
                return View();
            }

            _db.Sliders.Add(slider);
            _db.SaveChanges();



            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Slider slider = _db.Sliders.FirstOrDefault(x => x.Id == id);
            _db.Sliders.Remove(slider);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
