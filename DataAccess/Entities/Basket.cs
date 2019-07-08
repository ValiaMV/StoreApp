using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }


        public List<BasketProduct> BasketProducts { get; set; }



        public Basket()
        {
            BasketProducts = new List<BasketProduct>();
        }
    }
}
