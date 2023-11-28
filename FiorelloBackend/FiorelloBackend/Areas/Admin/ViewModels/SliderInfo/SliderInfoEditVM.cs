using System;
using System.ComponentModel.DataAnnotations;

namespace FiorelloBackend.Areas.Admin.ViewModels.SliderInfo
{
	public class SliderInfoEditVM
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
        public string SignImg { get; set; }
    }
}

