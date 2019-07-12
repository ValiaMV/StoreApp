using AutoMapper;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Managers
{
    public class ProductManager
    {
        private StoreApplicationContext _context;

        private IMapper _mapper;



        public ProductManager(StoreApplicationContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(StoreApplicationContext));
            _context = context ?? throw new ArgumentNullException(nameof(IMapper));
        }
        public IEnumerable<ProductModel> GetAllProducts()
        {
            var products = _context.Products
                .Include(prod => prod.Category)
                .ToList();

            var allProducts = new List<ProductModel>();
            if(products.Count != 0)
            {
                allProducts = _mapper.Map<IEnumerable<Product>, List<ProductModel>>(products);
            }

            return allProducts;
        }


        public IEnumerable<ProductModel> GetProducts(int categoryId)
        {
            var products = _context.Products
                .Include(prod => prod.Category)
                .Where(product => product.CategoryId == categoryId)
                .ToList();

            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);
        }

        public void AddProductToBasket(string userId, int productId)
        {
            var basket = _context.Baskets
                .Include(b => b.BasketProducts)
                .ThenInclude(bp => bp.Product)
                .SingleOrDefault(b => b.UserId == userId);

            if(basket != null)
            {
                var existBasketProduct = _context.BasketProducts.Where(bp => bp.BasketId == basket.Id).Where(bp => bp.ProductId == productId).FirstOrDefault();
                if(existBasketProduct == null)
                {
                    _context.BasketProducts
                        .Add(new BasketProduct { BasketId = basket.Id, ProductId = productId, Count = 1 });
                }
                else
                {
                    existBasketProduct.Count++;
                }
                _context.SaveChanges();
            }
        }
    }
}
