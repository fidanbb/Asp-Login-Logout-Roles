using System;
using AutoMapper;
using FiorelloBackend.Areas.Admin.ViewModels.Slider;
using FiorelloBackend.Areas.Admin.ViewModels.SliderInfo;
using FiorelloBackend.Data;
using FiorelloBackend.Helpers.Extentions;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloBackend.Services
{
	public class SliderInfoService:ISliderInfoService
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public SliderInfoService(AppDbContext context,
                                 IWebHostEnvironment env,
                                 IMapper mapper)
		{
            _context = context;
            _env = env;
            _mapper = mapper;
		}

        public async Task CreateAsync(SliderInfoCreateVM sliderInfo)
        {
            string fileName = $"{Guid.NewGuid()}-{sliderInfo.Photo.FileName}";

            string path = _env.GetFilePath("img", fileName);

            await _context.SliderInfos.AddAsync(new SliderInfo {Title=sliderInfo.Title,Description=sliderInfo.Description,SignImg=fileName});

            await _context.SaveChangesAsync();

            await sliderInfo.Photo.SaveFileAsync(path);
        }

        public async Task DeleteAsync(int id)
        {
            SliderInfo sliderInfo = await _context.SliderInfos.FirstOrDefaultAsync(m => m.Id == id);
            _context.SliderInfos.Remove(sliderInfo);
            await _context.SaveChangesAsync();

            string path = _env.GetFilePath("img", sliderInfo.SignImg);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task EditAsync(SliderInfoEditVM sliderInfo)
        {
            
            string fileName;
            
            if (sliderInfo.Photo is not null)
            {
                string oldPath = _env.GetFilePath("img", sliderInfo.SignImg);
                fileName = $"{Guid.NewGuid()}-{sliderInfo.Photo.FileName}";
                string newPath = _env.GetFilePath("img", fileName);
                if (File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }

                await sliderInfo.Photo.SaveFileAsync(newPath);

            }
            else
            {
                fileName = sliderInfo.SignImg;
            }



            SliderInfo dbSliderInfo = await _context.SliderInfos.FirstOrDefaultAsync(m => m.Id == sliderInfo.Id);

            dbSliderInfo.SignImg = fileName;
            dbSliderInfo.Title = sliderInfo.Title;
            dbSliderInfo.Description = sliderInfo.Description;

            _context.SliderInfos.Update(dbSliderInfo);
            await _context.SaveChangesAsync();

          
        }

        public async Task<SliderInfoVM> GetByIdAsync(int id)
        {


            return await _context.SliderInfos.Where(m => m.Id == id)
                                             .Select(m => new SliderInfoVM { Id = m.Id, Title = m.Title, Description = m.Description, SignImg = m.SignImg })
                                             .FirstOrDefaultAsync();
        }

        public async Task<SliderInfoVM> GetDataAsync()
        {
            var data = await _context.SliderInfos.FirstOrDefaultAsync();

            SliderInfoVM sliderInfo = _mapper.Map<SliderInfoVM>(data);

            //var entity = _mapper.Map<SliderInfo>(sliderInfo);

            //_mapper.Map(data, sliderInfo);

            return sliderInfo;

            //return await _context.SliderInfos.Select(m => new SliderInfoVM { Id = m.Id, Title=m.Title,Description=m.Description,SignImg=m.SignImg })
            //                             .FirstOrDefaultAsync();
        }
    }
}

