using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Managers;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class BasketController : Controller
    {
        private BasketManager _manager;

        private IMapper _mapper;

        private UserManager<StoreUser> _userManager;


        public BasketController(BasketManager manager, IMapper mapper, UserManager<StoreUser> userManager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(BasketManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(UserManager<StoreUser>));
        }
        public IActionResult Index()
        {
            var product = _mapper.Map<IEnumerable<ProductModel>, IEnumerable<ProductViewModel>>(_manager.GetProductsFromBasket(_userManager.GetUserId(User)));
            return View(product);
        }

        public IActionResult ClearAll()
        {
            _manager.Clear(_userManager.GetUserId(User));
            return RedirectToAction("Index");
        }
    }
}