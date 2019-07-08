using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Managers;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class BasketController : Controller
    {
        private BasketManager _manager;

        private IMapper _mapper;


        public BasketController(BasketManager manager, IMapper mapper)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(BasketManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }
        public IActionResult Index()
        {
            var product = _mapper.Map<IEnumerable<ProductModel>, IEnumerable<ProductViewModel>>(_manager.GetProductsFromBasket("123"));
            return View(product);
        }

        public IActionResult ClearAll()
        {
            _manager.Clear("123");
            return RedirectToAction("Index");
        }
    }
}