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
    public class OrderController : Controller
    {
        private BasketManager _basketManager;

        private OrderManager _orderManager;

        private IMapper _mapper;

        private UserManager<StoreUser> _userManager;


        private string _userId;

        public OrderController(
            BasketManager basketManager,
            OrderManager orderManager,
            IMapper mapper,
            UserManager<StoreUser> userManager)
        {
            _orderManager = orderManager ?? throw new ArgumentNullException(nameof(OrderManager));
            _basketManager = basketManager ?? throw new ArgumentNullException(nameof(BasketManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(UserManager<StoreUser>));

        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var products = _mapper.Map<IEnumerable<ProductModel>, IEnumerable<ProductViewModel>>(_basketManager.GetProductsFromBasket(userId));
            OrderViewModel orderModel = new OrderViewModel
            {
                UserId = userId,
                Products = products,
                TotalPrice = products.Select( p => Convert.ToInt32(p.Price)).Sum()                
            };
            return View(orderModel);
        }


        [HttpPost]
        [Authorize]
        public IActionResult MakeOrder(OrderViewModel model)
        {
            return View();
        }
    }
}