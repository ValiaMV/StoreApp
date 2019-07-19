using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data;

namespace StoreApp.Controllers.Administration
{
    public class UsersController : Controller
    {

        private readonly UserManager<StoreUser> _userManager;

        public UsersController(UserManager<StoreUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var users = _userManager.Users.ToArray();
            return View(users);
        }
    }
}