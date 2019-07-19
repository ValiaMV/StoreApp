using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Data;

namespace StoreApp.Areas.Identity.Pages.Account.Manage
{
    public class OrdersModel : PageModel
    {
        private readonly OrderManager _orderManager;

        private readonly UserManager<StoreUser> _userManager;

        public OrdersModel(
            OrderManager orderManager,
            UserManager<StoreUser> userManager)
        {
            _orderManager = orderManager;
            _userManager = userManager;
        }
        public class Order
        {
            public int Id { get; set; }

            public DateTime OpenDate { get; set; }

            public int TotalPrice { get; set; }
        }
        public IEnumerable<Order> Orders { get; set; }


        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var ordersmodel = _orderManager.GetOrders(_userManager.GetUserId(User));

            Orders = ordersmodel
                .Select(o => new Order { Id = o.Id, OpenDate = o.OpenDate, TotalPrice = o.TotalPrice });

            return Page();
        }
    }
}