using AutoMapper;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
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
                _context.Orders.Add(
                    _mapper.Map<OrderModel, Order>(model)
                    ); ;
            }
        }
    }
}
