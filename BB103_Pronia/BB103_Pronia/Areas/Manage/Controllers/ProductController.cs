
using Microsoft.AspNetCore.Mvc;

namespace BB103_Pronia.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Products.Include(p=>p.Category).Include(p=>p.ProductTags).ThenInclude(p=>p.Tag).Include(p=>p.ProductImages).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories=await _context.Categories.ToListAsync();
            ViewBag.Tags=await _context.Tags.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProduct createProduct)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();

            if (createProduct is null) return View("Error");
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool resultCategory = await _context.Categories.AnyAsync(c => c.Id == createProduct.CategoryId);
            if (!resultCategory)
            {
                ModelState.AddModelError("CategoryId", "Bele bir category movcud deyil");
                return View();
            }
            Random rnd = new Random(3);
            Product product = new Product()
            {
                Name = createProduct.Name,
                SKU=createProduct.Name.Substring(0,2).ToUpper()+"-"+rnd.Next(100,999),
                Description = createProduct.Description,
                Price = createProduct.Price,
                CategoryId = createProduct.CategoryId,
                ProductImages = new List<ProductImage>()
            };
            foreach (var item in createProduct.TagIds)
            {
                bool resultTag = await _context.Tags.AnyAsync(c => c.Id == item);
                if (!resultTag)
                {
                    ModelState.AddModelError("TagIds", "Bele bir tag movcud deyil");
                    return View();
                }
                
                ProductTag productTag = new ProductTag()
                {
                    Product = product,
                    TagId = item,
                };
                
                await _context.ProductTags.AddAsync(productTag);
            }

            //main photo
            if(!createProduct.MainPhoto.CheckContent("image/"))
            {
                ModelState.AddModelError("MainPhoto", "Duzgun format daxil edin");
                return View();
            }
            if(!createProduct.MainPhoto.CheckLenght(2097152))
            {
                ModelState.AddModelError("MainPhoto", "Maxsimum 2mb ola biler");
                return View();
            }
            if (!createProduct.HoverPhoto.CheckContent("image/"))
            {
                ModelState.AddModelError("HoverPhoto", "Duzgun format daxil edin");
                return View();
            }
            if (!createProduct.HoverPhoto.CheckLenght(2097152))
            {
                ModelState.AddModelError("HoverPhoto", "Maxsimum 2mb ola biler");
                return View();
            }
            ProductImage mainImage = new ProductImage()
            {
                IsPrime = true,
                Product = product,
                ImgUrl = createProduct.MainPhoto.UploadFile(_env.WebRootPath,@"\Upload\Product\")
            };

            ProductImage hoverImage = new ProductImage()
            {
                IsPrime = false,
                Product = product,
                ImgUrl = createProduct.HoverPhoto.UploadFile(_env.WebRootPath,"/Upload/Product/")
            };
            product.ProductImages.Add(mainImage);
            product.ProductImages.Add(hoverImage);
            TempData["Error"] = "";
            if(createProduct.Photos!=null)
            {
                foreach (IFormFile imgFile in createProduct.Photos)
                {
                    if (!imgFile.CheckContent("image/"))
                    {
                        TempData["Error"] += $"{imgFile.FileName} uygun tipde deyil ";
                        continue;
                    }
                    if (!imgFile.CheckLenght(2097152))
                    {
                        TempData["Error"] += $"{imgFile.FileName} file-nin olcusu coxdur";
                        continue;
                    }
                    ProductImage productImage = new ProductImage()
                    {
                        IsPrime = null,
                        Product = product,
                        ImgUrl = imgFile.UploadFile(_env.WebRootPath, "/Upload/Product/")
                    };
                    product.ProductImages.Add(productImage);

                }
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();  


            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id <= 0) return View("Error");
            Product exsistProduct=await _context.Products.Include(p=>p.Category)
                .Include(p=>p.ProductTags)
                .ThenInclude(pt=>pt.Tag)
                .Include(p=>p.ProductImages)
                .Where(c => c.Id == id).FirstOrDefaultAsync();
            if (exsistProduct == null) return View("Error");
            UpdateProduct updateProduct = new UpdateProduct()
            {
                Id = exsistProduct.Id,
                Name = exsistProduct.Name,
                SKU = exsistProduct.SKU,
                Description = exsistProduct.Description,
                Price = exsistProduct.Price,
                CategoryId = exsistProduct.CategoryId,
                TagIds = exsistProduct.ProductTags.Select(p => p.TagId).ToList(),
                ProductImagesVm = new List<ProductImageVm>()
            };

            foreach(var item in exsistProduct.ProductImages)
            {
                ProductImageVm productImageVm = new ProductImageVm()
                {
                    Id = item.Id,
                    ImgUrl = item.ImgUrl,
                    IsPrime = item.IsPrime,
                };
                updateProduct.ProductImagesVm.Add(productImageVm);
            }


            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();



            return View(updateProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProduct updateProduct)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            
            if (updateProduct.Id == null || updateProduct.Id <= 0) return View("Error");
            Product exsistProduct = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .Include(p=>p.ProductImages)
                .Where(c => c.Id == updateProduct.Id).FirstOrDefaultAsync();
            if (exsistProduct == null) return View("Error");
            updateProduct.ProductImagesVm = new List<ProductImageVm>();
            foreach (var item in exsistProduct.ProductImages)
            {
                ProductImageVm productImageVm = new ProductImageVm()
                {
                    Id = item.Id,
                    ImgUrl = item.ImgUrl,
                    IsPrime = item.IsPrime,
                };
                updateProduct.ProductImagesVm.Add(productImageVm);
            }
            if (!ModelState.IsValid)
            {
                return View(updateProduct);
            }
            TempData["Error"] = "";
            bool resultCategory = await _context.Categories.AnyAsync(c => c.Id == updateProduct.CategoryId);
            if (!resultCategory)
            {
                ModelState.AddModelError("CategoryId", "Bele bir category movcud deyil");
                return View(updateProduct);
            }

            foreach (var item in updateProduct.TagIds)
            {
                bool resultTag = await _context.Tags.AnyAsync(c => c.Id == item);
                if (!resultTag)
                {
                    ModelState.AddModelError("TagIds", "Bele bir tag movcud deyil");
                    return View(updateProduct);
                }
            }
            Random rnd = new Random();

            List<int> newSelectTagId = updateProduct.TagIds.Where(tagId =>!exsistProduct.ProductTags.Exists(p => p.TagId == tagId)).ToList();
            exsistProduct.SKU = updateProduct.Name.Substring(0, 2).ToUpper() + "-" + rnd.Next(100, 999);
            exsistProduct.Price = updateProduct.Price;
            exsistProduct.Description = updateProduct.Description;
            exsistProduct.Name = updateProduct.Name;
            exsistProduct.CategoryId=updateProduct.CategoryId;
            foreach (var newTagId in newSelectTagId)
            {
                ProductTag productTag = new ProductTag()
                {
                    TagId = newTagId,
                    ProductId = updateProduct.Id,
                };
                _context.ProductTags.Add(productTag);
            }
            List<ProductTag> removedTag = exsistProduct.ProductTags.Where(pt => !updateProduct.TagIds.Contains(pt.TagId)).ToList();
             _context.ProductTags.RemoveRange(removedTag);
            if(updateProduct.MainPhoto!=null)
            {
                if (!updateProduct.MainPhoto.CheckContent("image/"))
                {
                    ModelState.AddModelError("MainPhoto", "Duzgun format daxil edin");
                    return View();
                }
                if (!updateProduct.MainPhoto.CheckLenght(2097152))
                {
                    ModelState.AddModelError("MainPhoto", "Maxsimum 2mb ola biler");
                    return View();
                }
                var existMainPhoto = exsistProduct.ProductImages.FirstOrDefault(p => p.IsPrime == true);
                existMainPhoto.ImgUrl.RemoveFile(_env.WebRootPath,@"\Upload\Product\");
                exsistProduct.ProductImages.Remove(existMainPhoto);
                ProductImage productImage = new ProductImage()
                {
                    ImgUrl = updateProduct.MainPhoto.UploadFile(_env.WebRootPath, @"\Upload\Product\"),
                    ProductId = exsistProduct.Id,
                    IsPrime = true
                };
                exsistProduct.ProductImages.Add(productImage);
            }
            if (updateProduct.HoverPhoto != null)
            {
                if (!updateProduct.HoverPhoto.CheckContent("image/"))
                {
                    ModelState.AddModelError("HoverPhoto", "Duzgun format daxil edin");
                    return View();
                }
                if (!updateProduct.HoverPhoto.CheckLenght(2097152))
                {
                    ModelState.AddModelError("HoverPhoto", "Maxsimum 2mb ola biler");
                    return View();
                }
                var existMainPhoto = exsistProduct.ProductImages.FirstOrDefault(p => p.IsPrime == false);
                existMainPhoto.ImgUrl.RemoveFile(_env.WebRootPath, @"\Upload\Product\");
                exsistProduct.ProductImages.Remove(existMainPhoto);
                ProductImage productImage = new ProductImage()
                {
                    ImgUrl = updateProduct.MainPhoto.UploadFile(_env.WebRootPath, @"\Upload\Product\"),
                    ProductId = exsistProduct.Id,
                    IsPrime = false
                };
                exsistProduct.ProductImages.Add(productImage);
            }

            List<ProductImage> removeList = exsistProduct.ProductImages.Where(pt => !updateProduct.ImageIds.Contains(pt.Id)&&pt.IsPrime==null).ToList();
            if(removeList.Count>0)
            {
                foreach(var item in removeList)
                {
                    exsistProduct.ProductImages.Remove(item);
                    item.ImgUrl.RemoveFile(_env.WebRootPath, @"\Upload\Product\");
                }
            }
            if(updateProduct.Photos!=null)
            {
                foreach (IFormFile imgFile in updateProduct.Photos)
                {
                    if (!imgFile.CheckContent("image/"))
                    {
                        TempData["Error"] += $"{imgFile.FileName} uygun tipde deyil ";
                        continue;
                    }
                    if (!imgFile.CheckLenght(2097152))
                    {
                        TempData["Error"] += $"{imgFile.FileName} file-nin olcusu coxdur";
                        continue;
                    }
                    ProductImage productImage = new ProductImage()
                    {
                        IsPrime = null,
                        ProductId = exsistProduct.Id,
                        ImgUrl = imgFile.UploadFile(_env.WebRootPath, "/Upload/Product/")
                    };
                    exsistProduct.ProductImages.Add(productImage);
                }
            }


    
        await _context.SaveChangesAsync();
           

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Product product =_context.Products.Include(p=>p.ProductImages).FirstOrDefault(p => p.Id == id);
            if(product == null) return View("Error");

            foreach(var item in product.ProductImages)
            {
                item.ImgUrl.RemoveFile(_env.WebRootPath, @"\Upload\Product\");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
