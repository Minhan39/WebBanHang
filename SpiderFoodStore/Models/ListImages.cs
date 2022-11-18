using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpiderFoodStore.Models
{
    public class ListImages
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [DisplayName("Image")]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}