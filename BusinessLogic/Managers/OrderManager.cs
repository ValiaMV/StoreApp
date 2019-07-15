using AutoMapper;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
    public class OrderManager
    {
        private StoreApplicationContext _context;

        private IMapper _mapper;

        public OrderManager(
            StoreApplicationContext context,
            IMapper mapper
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(StoreApplicationContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        public async Task MakeOrder(OrderModel model)
        {
            if(model != null)
            {
               await  _context.Orders.AddAsync(
                    _mapper.Map<OrderModel, Order>(model)
                    ); 
            }
        }

        public int GetTotalPrice(string userId)
        {
            var basket = _context.Baskets.Include(b => b.BasketProducts).Single(b => b.UserId == userId);
            var products = _context.BasketProducts.Include(bp => bp.Product).Where(bp => bp.BasketId == basket.Id);
            return products.Sum(bp => Convert.ToInt32(bp.Product.Price) * bp.Count);
        }
    }
}
