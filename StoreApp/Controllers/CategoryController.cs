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
    public class CategoryController : Controller
    {
        private CategoryManager _manager;

        private IMapper _mapper;
        public CategoryController(CategoryManager manager, IMapper mapper)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(CategoryManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProducts(int categoryId)
        {
            return LocalRedirect("~/Product/Index/" + categoryId);
        }
    }
}