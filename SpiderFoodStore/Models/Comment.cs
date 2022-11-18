using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpiderFoodStore.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string Content { get; set; }
        public int Parent { get; set; }
    }
}