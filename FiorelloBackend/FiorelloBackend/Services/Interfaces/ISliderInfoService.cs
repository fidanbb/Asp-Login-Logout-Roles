using System;
using FiorelloBackend.Areas.Admin.ViewModels.SliderInfo;

namespace FiorelloBackend.Services.Interfaces
{
	public interface ISliderInfoService
	{
		Task<SliderInfoVM> GetDataAsync();
		Task<SliderInfoVM> GetByIdAsync(int id);
		Task DeleteAsync(int id);
		Task CreateAsync(SliderInfoCreateVM sliderInfo);
		Task EditAsync(SliderInfoEditVM sliderInfo);
	}
}

