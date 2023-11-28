using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloBackend.Areas.Admin.ViewModels.Slider;
using FiorelloBackend.Areas.Admin.ViewModels.SliderInfo;
using FiorelloBackend.Data;
using FiorelloBackend.Helpers.Extentions;
using FiorelloBackend.Models;
using FiorelloBackend.Services;
using FiorelloBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderInfoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISliderInfoService _sliderInfoService;

        public SliderInfoController(AppDbContext context,ISliderInfoService sliderInfoService)
        {
            _context = context;
            _sliderInfoService = sliderInfoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _sliderInfoService.GetDataAsync());
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            SliderInfoVM sliderInfo = await _sliderInfoService.GetByIdAsync((int)id);

            if (sliderInfo is null) return NotFound();

            return View(sliderInfo);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(SliderInfoCreateVM sliderInfo)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }

            if (!sliderInfo.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File can be only image format");
                return View();
            }

            if (!sliderInfo.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "File size can be max 200 kb");
                return View();
            }

            await _sliderInfoService.CreateAsync(sliderInfo);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            SliderInfoVM sliderInfo = await _sliderInfoService.GetByIdAsync((int)id);
            if (sliderInfo is null) return NotFound();

            return View(new SliderInfoEditVM { Title=sliderInfo.Title,Description=sliderInfo.Description,SignImg=sliderInfo.SignImg});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SliderInfoEditVM sliderInfo)
        {
            if (id is null) return BadRequest();

            SliderInfoVM dbSliderInfo = await _sliderInfoService.GetByIdAsync((int)id);

            if (dbSliderInfo is null) return NotFound();

            sliderInfo.SignImg = dbSliderInfo.SignImg;


            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors);

            //    return Ok(errors);
            //    //return View(sliderInfo);
            //}

            if (sliderInfo.Photo is null)
            {
                await _sliderInfoService.EditAsync(sliderInfo);
                return RedirectToAction(nameof(Index));
            }


            if (!sliderInfo.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File can be only image format");
                return View(sliderInfo);
            }

            if (!sliderInfo.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "File size can be max 200 kb");
                return View(sliderInfo);
            }


            await _sliderInfoService.EditAsync(sliderInfo);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderInfoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

