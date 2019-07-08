using AutoMapper;
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

        private IMapper _mapper;

        public Manager(StoreApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(StoreApplicationContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        public IEnumerable<ProductModel> GetProductFromBasket(string userId)
        {
            var basket = _context.Baskets.Include(b => b.BasketProducts).ThenInclude(bp => bp.Product).ThenInclude(p => p.Category).Where(b => b.UserId == userId).FirstOrDefault() ?? new Basket();

            var products = new List<ProductModel>();
            if(basket.BasketProducts.Count != 0)
            {
                var product = basket.BasketProducts.Where(b => b.BasketId == basket.Id).Select(bp => bp.Product).ToList();

                products = _mapper.Map<List<Product>, List<ProductModel>>(product);
            }

            return products;
        }
    }
}
