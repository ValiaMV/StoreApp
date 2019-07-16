using AutoMapper;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Managers
{
    public class DeliveryManager
    {
        private StoreApplicationContext _context;

        private IMapper _mapper;

        public DeliveryManager(
            StoreApplicationContext context,
            IMapper mapper
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(StoreApplicationContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }


        public IEnumerable<DeliveryModel> GetDeliveryTypes()
        {
            return _mapper.Map<IEnumerable<Delivery>, IEnumerable<DeliveryModel>>(_context.Deliveries.ToList());
        }
    }
}
