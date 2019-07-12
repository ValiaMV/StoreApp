using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class Delivery
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public List<Order> Orders { get; set; }
    }
}
