using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Delivery
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public List<Order> Orders { get; set; }
    }
}
