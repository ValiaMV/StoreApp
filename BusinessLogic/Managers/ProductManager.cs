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
            var products = _context.Products.Include(prod => prod.Category).ToList();

            var allProducts = new List<ProductModel>();
            if(products.Count != 0)
            {
                allProducts = _mapper.Map<IEnumerable<Product>, List<ProductModel>>(products);
            }


            return allProducts;
        }
    }
}
