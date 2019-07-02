using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public int CategoryId { get; set; }
    }
}
