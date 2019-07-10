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
        public IActionResult Index()
        {
            var productsData = _mapper.Map<IEnumerable<ProductModel>, IEnumerable<ProductViewModel>>(_manager.GetAllProducts());
            return View(productsData);
        }

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