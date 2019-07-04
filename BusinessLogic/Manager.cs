using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Manager
    {
        private StoreApplicationContext _context;

        public Manager(StoreApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(StoreApplicationContext));
        }

        public IEnumerable<ProductModel> GetProductFromBasket(string userId)
        {
            var products = _context.Baskets.Include(basket => basket.BasketProducts).Where(basket => basket.UserId == userId).FirstOrDefault() ?? new Basket();



        }
    }
}
