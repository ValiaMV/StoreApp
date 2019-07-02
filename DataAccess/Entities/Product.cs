using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<BasketProduct> BasketProducts { get; set; }
    }
}
