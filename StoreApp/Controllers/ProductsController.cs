using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Managers;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private UserManager<StoreUser> _userManager;
        private ProductManager _manager { get; set; }
        private IMapper _mapper { get; set; }

        public ProductController(
            ProductManager manager, 
            IMapper mapper,
            UserManager<StoreUser> userManager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(ProductManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(UserManager<StoreUser>));
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(int id)
        {

            var productsData = id == 0 ? _manager.GetAllProducts() : _manager.GetProducts(id);
            var products = _mapper.Map<IEnumerable<ProductModel>, IEnumerable<ProductViewModel>>(productsData);
            return View(products);
        }




        [HttpGet]
        [Authorize]
        public IActionResult Add(int id)
        {
            if(id != 0)
            {
                var userId = _userManager.GetUserId(User);
                _manager.AddProductToBasket(userId, id);
            }
            return RedirectToAction("Index");

        }
    }
}