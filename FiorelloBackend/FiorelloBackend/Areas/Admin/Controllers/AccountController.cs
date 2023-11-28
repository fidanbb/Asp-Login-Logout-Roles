using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloBackend.Areas.Admin.ViewModels.Account;
using FiorelloBackend.Areas.Admin.ViewModels.SliderInfo;
using FiorelloBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiorelloBackend.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddRoleToUser()
        {
            ViewBag.roles = await GetRoles();

            ViewBag.users = await GetUsers();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dbUsers = await _userManager.Users
                                          //.Select(m => new UserVM { FullName = m.FullName, Email = m.Email, Username = m.UserName })
                                          .ToListAsync();

            List<UserVM> users=new();
            foreach (var user in dbUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);
                users.Add(new UserVM
                {
                    FullName=user.FullName,
                    Email=user.Email,
                    Username=user.UserName,
                    RoleNames=roles
                });
            }

            return View(users);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoleToUser(UserRoleVM request)
        {
            AppUser user = await _userManager.FindByIdAsync(request.UserId);

            IdentityRole role = await _roleManager.FindByIdAsync(request.RoleId);

            await _userManager.AddToRoleAsync(user,role.Name);

            return RedirectToAction("Index");
        }


        private async Task<SelectList> GetRoles()
        {
            var roles =await _roleManager.Roles.ToListAsync();

            return new SelectList(roles, "Id", "Name");
        }

        private async Task<SelectList> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            return new SelectList(users, "Id", "UserName");
        }

    }
}

