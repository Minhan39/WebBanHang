using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpiderFoodStore.Models
{
    public class OrderDetailBill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Money
        {
            get
            {
                return Amount * Price;
            }
        }
    }
}