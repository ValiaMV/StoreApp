using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class BasketController : Controller
    {
        private Manager _manager;

        private IMapper _mapper;


        public BasketController(Manager manager, IMapper mapper)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(Manager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }
        public IActionResult Index()
        {
            var product = _mapper.Map<IEnumerable<ProductModel>, IEnumerable<ProductViewModel>>(_manager.GetProductFromBasket("123"));
            return View(product);
        }
    }
}