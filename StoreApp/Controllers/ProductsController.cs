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
    public class ProductController : Controller
    {
        private ProductManager _manager { get; set; }
        private IMapper _mapper { get; set; }

        public ProductController(ProductManager manager, IMapper mapper)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(ProductManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }
        public IActionResult Index()
        {
            var productsData = _mapper.Map<IEnumerable<ProductModel>, IEnumerable<ProductViewModel>>(_manager.GetAllProducts());
            return View(productsData);
        }
    }
}