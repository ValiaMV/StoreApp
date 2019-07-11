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
            var basket = _context.Baskets.Include(b => b.BasketProducts).ThenInclude(bp => bp.Product).ThenInclude(p => p.Category).SingleOrDefault(b => b.UserId == userId) ?? new Basket();

            var products = new List<ProductModel>();
            if(basket.BasketProducts.Count != 0)
            {
                var product = basket.BasketProducts.Where(b => b.BasketId == basket.Id).Select(bp => bp.Product).ToList();

                products = _mapper.Map<List<Product>, List<ProductModel>>(product);

                products.ForEach(p => p.Count = basket.BasketProducts.Single(pc => pc.ProductId == p.Id).Count);
            }

            return products;
        }
        public void Clear(string userId)
        {
            var basket = _context.Baskets.Include(b => b.BasketProducts).SingleOrDefault(b => b.UserId == userId);

            if(basket != null && basket.BasketProducts.Count != 0)
            {
                _context.BasketProducts.RemoveRange(_context.BasketProducts.Where(bp => basket.BasketProducts.Select(bprod => bprod.Product).Contains(bp.Product)));
                _context.SaveChanges();

            }

        }



        public void Create(string userId)
        {
            if(userId != null)
            {
                _context.Baskets.Add(new Basket { Name = "Basket_" + userId, UserId = userId });
                _context.SaveChanges();
            }
        }


        public void Delete(string userId, int productId)
        {
            if(userId != null && productId != 0)
            {
                var basket = _context.Baskets.SingleOrDefault(b => b.UserId == userId);
                if(basket != null)
                {
                    var product = _context.BasketProducts.Where(bp => bp.BasketId == basket.Id).SingleOrDefault(bp => bp.ProductId == productId);
                    _context.BasketProducts.Remove(product);
                    _context.SaveChanges();
                }
            }
        }

        public void SetCount(string userId, int productId, int count)
        {
            if(userId != null && productId > 0 && count > 0)
            {
                var basket = _context.Baskets.SingleOrDefault(b => b.UserId == userId);
                _context.BasketProducts.SingleOrDefault(bp => bp.ProductId == productId && bp.BasketId == basket.Id).Count = count;
                _context.SaveChanges();
            }
        }
    }
}
