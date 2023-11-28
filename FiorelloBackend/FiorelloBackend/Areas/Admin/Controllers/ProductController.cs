using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloBackend.Areas.Admin.ViewModels.Product;
using FiorelloBackend.Data;
using FiorelloBackend.Helpers;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FiorelloBackend.Helpers.Extentions;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiorelloBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService,
                                 AppDbContext context,
                                 ICategoryService categoryService,
                                 IWebHostEnvironment env)
        {
            _productService = productService;
            _context = context;
            _categoryService = categoryService;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page=1,int take=4)
        {
            List<ProductVM> dbPaginatedDatas = await _productService.GetPaginatedDatasAsync(page, take);
            int pageCount = await GetPageCountAsync(take);

            Paginate<ProductVM> paginatedDatas = new(dbPaginatedDatas, page, pageCount);

            return View(paginatedDatas);
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            int productCount = await _productService.GetCountAsync();

            return (int)Math.Ceiling((decimal)(productCount) / take);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _productService.GetByIdWithIncludesAsnyc((int)id);

            if (product is null) return NotFound();

            return View(product);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ProductCreateVM request)
        {
            ViewBag.categories = await GetCategoriesAsync();

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            foreach (var photo in request.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photos","File can only be in image format ");
                    return View(request);
                }

                if (!photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photos", "File size can be max 200kb");
                    return View(request);
                }
            }

            List<ProductImage> newImages = new();

            foreach (var photo in request.Photos)
            {
                string fileName = $"{Guid.NewGuid()}-{photo.FileName}";

                string path = _env.GetFilePath("img",fileName);

                await photo.SaveFileAsync(path);

                newImages.Add(new ProductImage { Image = fileName });
            }

            newImages.FirstOrDefault().IsMain = true;
            await _context.ProductImages.AddRangeAsync(newImages);


            await _context.Products.AddAsync(

                  new Product
                  {
                      Name = request.Name,
                      Description=request.Description,
                      Price=request.Price,
                      CategoryId=request.CategoryId,
                      Images=newImages
                  });

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _context.Products.Include(m => m.Images).FirstOrDefaultAsync(m=>m.Id==id);

            if (product is null) return NotFound();

            _context.Products.Remove(product);


            await _context.SaveChangesAsync();

            foreach (var productImage in product.Images)
            {
                string path = _env.GetFilePath("img", productImage.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

            //if (id is null) return BadRequest();

            //Product product = await _productService.GetByIdAsync((int)id);

            //if (product is null) return NotFound();

            //_context.Products.Remove(product);

            //List<ProductImage> productImages = await _context.ProductImages.Where(m => m.ProductId == id).ToListAsync();

            //_context.ProductImages.RemoveRange(productImages);

            //await _context.SaveChangesAsync();

            //foreach (var productImage in productImages)
            //{
            //    string path = _env.GetFilePath("img", productImage.Image);
            //    if (System.IO.File.Exists(path))
            //    {
            //        System.IO.File.Delete(path);
            //    }
            //}

            return RedirectToAction(nameof(Index));
        }

     


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.categories = await GetCategoriesAsync();

            if (id is null) return BadRequest();

            Product product = await _productService.GetByIdWithIncludesAsnyc((int)id);
           
            if (product is null) return NotFound();

            return View(new ProductEditVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = (int)product.CategoryId,
                Price = product.Price,
                Images = product.Images.ToList(),
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ProductEditVM request)
        {
            ViewBag.categories = await GetCategoriesAsync();

            if (id is null) return BadRequest();

            Product product = await _productService.GetByIdWithIncludesAsnyc((int)id);

            if (product is null) return NotFound();

            request.Images = product.Images.ToList();

            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(request);

            }

            List<ProductImage> newImages = new();

            if (request.Photos != null)
            {
                foreach (var photo in request.Photos)
                {

                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photos", "File can be only image format");
                        return View(request);
                    }

                    if (!photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photos", "File size can be max 200 kb");
                        return View(request);
                    }
                }

                foreach (var photo in request.Photos)
                {
                    string fileName = $"{Guid.NewGuid()}-{photo.FileName}";

                    string path = _env.GetFilePath("img", fileName);

                    await photo.SaveFileAsync(path);

                    newImages.Add(new ProductImage { Image = fileName });
                }

                await _context.ProductImages.AddRangeAsync(newImages);
            }

            newImages.AddRange(request.Images);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            product.Images = newImages;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            ProductImage image = await _context.ProductImages.Where(m => m.Id == id).FirstOrDefaultAsync();
            _context.ProductImages.Remove(image);

            await _context.SaveChangesAsync();

            string path = _env.GetFilePath("img", image.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return Ok();
        }

        private async Task<SelectList> GetCategoriesAsync()
        {
            return new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        }

    }
}

