﻿using System;
using AutoMapper;
using FiorelloBackend.Areas.Admin.ViewModels.Product;
using FiorelloBackend.Areas.Admin.ViewModels.SliderInfo;
using FiorelloBackend.Models;

namespace FiorelloBackend.Helpers.Mappings
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
            CreateMap<SliderInfo, SliderInfoVM>();
            CreateMap<Product, ProductVM>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                                           .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Images.FirstOrDefault(m=>m.IsMain).Image));
        }
    }
}

