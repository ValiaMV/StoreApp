﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int TotalPrice { get; set; }

        public string Address { get; set; }

        public DeliveryModel Delivery { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }

    }
}