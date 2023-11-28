using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloBackend.Data;
using FiorelloBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiorelloBackend.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {

            int productCount = await _context.Products.Where(m => !m.SoftDeleted)
                                                      .CountAsync();


            IEnumerable<Product> products = await _context.Products.Where(m => !m.SoftDeleted)
                                                                  .Include(mn => mn.Images)
                                                                  .Take(4)
                                                                  .ToListAsync();

            ViewBag.count = productCount;
            return View(products);
        }

        public async Task<IActionResult> LoadMore(int skipCount)
        {
            List<Product> products = await _context.Products.Where(m => !m.SoftDeleted)
                                                                     .Include(m => m.Images)
                                                                     .Skip(skipCount)
                                                                     .Take(4)
                                                                     .ToListAsync();
            return PartialView("_ProductsPartial",products);
        }
    }
}

