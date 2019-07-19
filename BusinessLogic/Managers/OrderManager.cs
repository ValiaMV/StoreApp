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
                var order = _mapper.Map<OrderModel, Order>(model); 

                await _context.Orders.AddAsync(order);

                var basket = _context.Baskets.Single(b => b.UserId == model.UserId);        
                
                _context.BasketProducts.RemoveRange(_context.BasketProducts.Where(bp => bp.BasketId == basket.Id));
                _context.SaveChanges();
            }
        }

        public int GetTotalPrice(string userId)
        {
            var basket = _context.Baskets.Include(b => b.BasketProducts).Single(b => b.UserId == userId);
            var products = _context.BasketProducts.Include(bp => bp.Product).Where(bp => bp.BasketId == basket.Id);
            return products.Sum(bp => Convert.ToInt32(bp.Product.Price) * bp.Count);
        }


        public IEnumerable<OrderModel> GetOrders(string userId)
        {
            var orders = _context.Orders.Where(o => o.UserId == userId);
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(orders);
        }
    }
}
