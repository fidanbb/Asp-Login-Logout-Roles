using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiorelloBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArchiveController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArchiveService _archiveService;

        public ArchiveController(ICategoryService categoryService,
                                 IArchiveService archiveService)
        {
            _categoryService = categoryService;
            _archiveService = archiveService;
        }


        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            return View(await _categoryService.GetArchiveDatasAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ExtractCategory(int id)
        {
            Category dbCategory = await _categoryService.GetSoftDeletedDataById(id);

            await _categoryService.ExtractAsync(dbCategory);

            return RedirectToAction(nameof(Categories));
        }

        [HttpGet]
        public async Task<IActionResult> ArchiveCategories()
        {
            return View(await _archiveService.GetCategoryArchive());
        }
    }
}

