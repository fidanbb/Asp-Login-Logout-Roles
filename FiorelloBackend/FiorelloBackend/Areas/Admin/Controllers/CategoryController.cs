using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloBackend.Areas.Admin.ViewModels.Product;
using FiorelloBackend.Data;
using FiorelloBackend.Helpers;
using FiorelloBackend.Models;
using FiorelloBackend.Services;
using FiorelloBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiorelloBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;
        public CategoryController(ICategoryService categoryService,
                                  AppDbContext context)
        {
            _categoryService=categoryService;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int page=1,int take=3)
        {
            List<Category> dbPaginatedDatas = await _categoryService.GetPaginatedDatasAsync(page, take);
            int pageCount = await GetPageCountAsync(take);

            Paginate<Category> paginatedDatas = new(dbPaginatedDatas, page, pageCount);

            return View(paginatedDatas);
        }


        private async Task<int> GetPageCountAsync(int take)
        {
            int productCount = await _categoryService.GetCountAsync();

            return (int)Math.Ceiling((decimal)(productCount) / take);
        }

        [HttpGet]
        [Authorize(Roles ="SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors);

                return View();
            }

            Category existCategory = await _categoryService.GetByNameAsync(category.Name);

            if (existCategory is not null)
            {
                ModelState.AddModelError("Name", "This name is already exists");
                return View();
            }

            await _categoryService.CreateAsync(category);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            //Category dbCategory = await _categoryService.GetByIdAsync(id, false);

            //await _categoryService.DeleteAsync(dbCategory);

            Category category = _context.Categories.Include(m => m.Products).ThenInclude(m=>m.Images).FirstOrDefault(m => m.Id == id);

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SoftDelete(int id)
        {
            Category dbCategory = await _categoryService.GetByIdAsync(id, true);

            await _categoryService.SoftDeleteAsync(dbCategory);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Category category= await _categoryService.GetByIdWitoutTrackingAsync((int)id);

            if (category is null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int? id,Category category)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            Category dbCategory = await _categoryService.GetByIdAsync((int)id,false);

            if (dbCategory is null) return NotFound();

            if (category.Name.Trim() == dbCategory.Name.Trim())
            {
                return RedirectToAction(nameof(Index));
            }

            Category existCategory = await _categoryService.GetByNameAsync(category.Name);

            if (existCategory is not null)
            {
                ModelState.AddModelError("Name", "This name is already exists");
                return View();
            }

            //dbCategory.Name = category.Name;

            await _categoryService.EditAsync(category);

            return RedirectToAction(nameof(Index)); 
        }
    }
}

