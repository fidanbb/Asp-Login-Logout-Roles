using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloBackend.Data;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using FiorelloBackend.ViewModels;
using FiorelloBackend.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FiorelloBackend.Controllers
{
    public class CartController : Controller
    {

        private readonly IBasketService _basketService;

        public CartController(IBasketService basketService)
        {
            _basketService=basketService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View(await _basketService.GetBasketDatasAsync());

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _basketService.DeleteItem(id);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Increase(int id)
        {
            var data = await _basketService.IncreaseItem(id);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Decrease(int id)
        {
            var data = await _basketService.DecreaseItem(id);

            return Ok(data);
        }
    }
}

