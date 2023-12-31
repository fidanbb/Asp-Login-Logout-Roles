﻿using System;
using System.Security.Claims;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using FiorelloBackend.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloBackend.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{
		private readonly ILayoutService _layoutService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public HeaderViewComponent(ILayoutService layoutService,
			                       UserManager<AppUser> userManager,
                                   IHttpContextAccessor httpContextAccessor)
		{
			_layoutService = layoutService;
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
		}


		public async Task<IViewComponentResult> InvokeAsync()
		{
			HeaderVM model =  _layoutService.GetHeaderDatas();

			var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			if(userId is not null)
			{
                AppUser currentUser = await _userManager.FindByIdAsync(userId);

                model.UserFullName = currentUser.FullName;
            }
			
			return await Task.FromResult(View(model));
		}
	}
}

