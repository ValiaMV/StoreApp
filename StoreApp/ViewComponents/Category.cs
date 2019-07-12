using AutoMapper;
using BusinessLogic.Managers;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly CategoryManager _manager;

        private readonly IMapper _mapper;
        public CategoryListViewComponent(CategoryManager manager, IMapper mapper)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(CategoryManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }
        public IViewComponentResult Invoke()
        {
            var categories = GetCategories();
            return View(categories);
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            var categories = _manager.GetCategories();
            return _mapper.Map<IEnumerable<CategoryModel>, IEnumerable<CategoryViewModel>>(categories);
        }
    }
}
