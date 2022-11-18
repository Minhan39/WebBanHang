using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpiderFoodStore.Models
{
    public class CommentCustomer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public int Parent { get; set; }
        public string ImagePath { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}