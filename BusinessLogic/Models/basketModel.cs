using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class BasketModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
