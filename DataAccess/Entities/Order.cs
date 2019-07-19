using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int TotalPrice { get; set; }

        public string Address { get; set; }

        public Delivery Delivery { get; set; }

        public int DeliveryId { get; set; }

        public DateTime OpenDate { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

    }
}
