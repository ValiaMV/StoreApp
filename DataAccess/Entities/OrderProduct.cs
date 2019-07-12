using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class OrderProduct
    {
        public Order Order { get; set; }

        public int OrderId { get; set; }



        public Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
