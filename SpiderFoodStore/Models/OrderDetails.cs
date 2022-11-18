﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpiderFoodStore.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public string OrderInvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}