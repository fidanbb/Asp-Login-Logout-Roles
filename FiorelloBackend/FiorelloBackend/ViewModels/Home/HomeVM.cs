using System;
using FiorelloBackend.Areas.Admin.ViewModels.Slider;
using FiorelloBackend.Areas.Admin.ViewModels.SliderInfo;
using FiorelloBackend.Models;

namespace FiorelloBackend.ViewModels.Home
{
	public class HomeVM
	{
        public List<SliderVM> Sliders { get; set; }
        public SliderInfoVM SliderInfo { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<Instagram> Instagrams { get; set; }
        public Subscribe Subscribe { get; set; }
        public List<Expert> Experts { get; set; }
        public ValentineOpportunity ValentineOpportunity { get; set; }
    }
}

