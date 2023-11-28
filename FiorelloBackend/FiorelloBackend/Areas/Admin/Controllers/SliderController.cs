using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloBackend.Areas.Admin.ViewModels.Slider;
using FiorelloBackend.Data;
using FiorelloBackend.Helpers.Extentions;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace FiorelloBackend.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            
            _sliderService = sliderService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _sliderService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            SliderVM slider = await _sliderService.GetByIdAsync((int)id);

            if (slider is null) return NotFound();

            return View(slider);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            foreach (var photo in slider.Photos)
            {

                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photos", "File can be only image format");
                    return View();
                }

                if (!photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photos", "File size can be max 200 kb");
                    return View();
                }
            }

            await _sliderService.CreateAsync(slider);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            SliderVM slider = await _sliderService.GetByIdAsync((int)id);

            if (slider is null) return NotFound();

            return View(new SliderEditVM { Image = slider.Image });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SliderEditVM slider)
        {
            if (id is null) return BadRequest();

            SliderVM dbSlider = await _sliderService.GetByIdAsync((int)id);

            if (dbSlider is null) return NotFound();

            slider.Image = dbSlider.Image;

            if (slider.Photo is null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File can be only image format");
                return View(slider);
            }

            if (!slider.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "File size can be max 200 kb");
                return View(slider);
            }


            await _sliderService.EditAsync(slider);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus(int id)
        {

            await _sliderService.ChangeStatus(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

