using System;
using FiorelloBackend.Areas.Admin.ViewModels.Slider;

namespace FiorelloBackend.Services.Interfaces
{
	public interface ISliderService
	{
        Task<List<SliderVM>> GetAllAsync();
        Task<List<SliderVM>> GetAllWithTrueStatusAsync();
        Task<SliderVM> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task EditAsync(SliderEditVM slider);
        Task CreateAsync(SliderCreateVM slider);
        Task<int> GetCountOfTrueStatus();
        Task ChangeStatus(int id);
    }
}

