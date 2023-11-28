using Newtonsoft.Json;
using FiorelloBackend.Data;
using FiorelloBackend.Models;
using FiorelloBackend.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiorelloBackend.Services.Interfaces;
using FiorelloBackend.Areas.Admin.ViewModels.Slider;
using FiorelloBackend.Areas.Admin.ViewModels.SliderInfo;

namespace FiorelloBackend.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly IProductService _productService;
    private readonly IBasketService _basketService;
    private readonly ISliderService _sliderService;
    private readonly ISliderInfoService _sliderInfoService;

    public HomeController(AppDbContext context,
                         IProductService productService,
                         IBasketService basketService,
                         ISliderService sliderService,
                         ISliderInfoService sliderInfoService)
    {
        _context = context;
        _productService = productService;
        _basketService = basketService;
        _sliderService = sliderService;
        _sliderInfoService = sliderInfoService;
    }


    [HttpGet]
    public async Task<IActionResult>  Index()

    {



        List<SliderVM> sliders = await _sliderService.GetAllWithTrueStatusAsync();
        SliderInfoVM sliderInfo =await _sliderInfoService.GetDataAsync();
        List<Product> products = await _productService.GetAllWithImagesByTakeAsync(12);
        List<Category> categories =await _context.Categories.Where(m => !m.SoftDeleted).ToListAsync();
        List<Testimonial> testimonials =await _context.Testimonials.Where(m => !m.SoftDeleted).ToListAsync();
        List<Instagram> instagrams =await _context.Instagrams.Where(m => !m.SoftDeleted).ToListAsync();
        Subscribe subscribe =await _context.Subscribes.FirstOrDefaultAsync();
        List<Expert> experts =await _context.Experts.Where(m => !m.SoftDeleted).ToListAsync();
        ValentineOpportunity valentineOpportunity =await _context.ValentineOpportunities.Where(m => !m.SoftDeleted).Include(m => m.OpportunityInfos).FirstOrDefaultAsync();

        HomeVM model = new()
        {
            Sliders = sliders,
            SliderInfo =sliderInfo,
            Products=products,
            Categories=categories,
            Testimonials=testimonials,
            Instagrams=instagrams,
            Subscribe=subscribe,
            Experts=experts,
            ValentineOpportunity=valentineOpportunity
        };

        return View(model);
    }



    [HttpPost]
   

    public async Task<IActionResult> AddBasket(int? id)
    {
        if (id is null) return BadRequest();

        Product product =await _productService.GetByIdAsync((int)id);

        if (product is null) NotFound();

        _basketService.AddBasket(id, product);

        return Ok();
    }

}




