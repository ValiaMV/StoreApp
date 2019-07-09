using AutoMapper;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Managers
{
    public class BasketManager
    {
        private StoreApplicationContext _context;

        private IMapper _mapper;

        public BasketManager(StoreApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(StoreApplicationContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        public IEnumerable<ProductModel> GetProductsFromBasket(string userId)
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
        public void Clear(string userId)
        {
            var basket = _context.Baskets.Include(b => b.BasketProducts).Where(b => b.UserId == userId).FirstOrDefault();

            if(basket != null && basket.BasketProducts.Count != 0)
            {
                _context.BasketProducts.RemoveRange(_context.BasketProducts.Where(bp => basket.BasketProducts.Select(bprod => bprod.Product).Contains(bp.Product)));
                _context.SaveChanges();

            }

        }


    }
}
