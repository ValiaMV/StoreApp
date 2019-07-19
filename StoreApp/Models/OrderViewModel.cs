using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int TotalPrice { get; set; }

        public string Address { get; set; }

        public int DeliveryId { get; set; }

        public DateTime OpenDate { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
