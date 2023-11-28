using System;
using FiorelloBackend.Areas.Admin.ViewModels.Slider;
using FiorelloBackend.Data;
using FiorelloBackend.Helpers.Extentions;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloBackend.Services
{
	public class SliderService:ISliderService
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task ChangeStatus(int id)
        {
            int count = await _context.Sliders.Where(m => m.Status).CountAsync();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (slider.Status)
            {
                if (count != 1)
                {
                    slider.Status = false;
                }
                else
                {
                    slider.Status = true;
                }

            }
            else
            {
                slider.Status = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(SliderCreateVM slider)
        {
            foreach (var photo in slider.Photos)
            {
                string fileName = $"{Guid.NewGuid()}-{photo.FileName}";

                string path = _env.GetFilePath("img", fileName);

                await _context.Sliders.AddAsync(new Slider { Img = fileName });

                await _context.SaveChangesAsync();

                await photo.SaveFileAsync(path);
            }
        }

        public async Task DeleteAsync(int id)
        {
            Slider slider = await _context.Sliders.Where(m => m.Id == id).FirstOrDefaultAsync();
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            string path = _env.GetFilePath("img", slider.Img);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task EditAsync(SliderEditVM slider)
        {
            string oldPath = _env.GetFilePath("img", slider.Image);

            string fileName = $"{Guid.NewGuid()}-{slider.Photo.FileName}";

            string newPath = _env.GetFilePath("img", fileName);

            Slider dbSlider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == slider.Id);

            dbSlider.Img = fileName;

            await _context.SaveChangesAsync();

            if (File.Exists(oldPath))
            {
                File.Delete(oldPath);
            }

            await slider.Photo.SaveFileAsync(newPath);
        }

        public async Task<List<SliderVM>> GetAllAsync()
        {
            return await _context.Sliders.Select(m => new SliderVM { Id = m.Id, Image = m.Img, Status = m.Status })
                                         .ToListAsync();

        }

        public async Task<List<SliderVM>> GetAllWithTrueStatusAsync()
        {
            return await _context.Sliders.Where(m => m.Status)
                                         .Select(m => new SliderVM { Id = m.Id, Image = m.Img, Status = m.Status })
                                         .ToListAsync();
        }

        public async Task<SliderVM> GetByIdAsync(int id)
        {

            return await _context.Sliders.Where(m => m.Id == id)
                                         .Select(m => new SliderVM { Id = m.Id, Image = m.Img, Status = m.Status })
                                         .FirstOrDefaultAsync();
        }

        public async Task<int> GetCountOfTrueStatus()
        {
            return await _context.Sliders.Where(m => m.Status).CountAsync();
        }
    }
}

