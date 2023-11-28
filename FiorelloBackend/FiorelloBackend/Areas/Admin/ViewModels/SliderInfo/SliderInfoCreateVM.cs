using System;
using System.ComponentModel.DataAnnotations;

namespace FiorelloBackend.Areas.Admin.ViewModels.SliderInfo
{
	public class SliderInfoCreateVM
	{
        [Required]
        [MaxLength(100, ErrorMessage = "Max length must be 100 symbols")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
    }
}

