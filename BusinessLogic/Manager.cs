using BusinessLogic.Models;
using DataAccess;
using System;
using System.Collections.Generic;

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

        }
    }
}
