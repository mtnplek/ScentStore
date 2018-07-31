using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScentStore.Models
{
    public class Product
    {
        
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int InStock { get; set; }
        [Required]
        public bool IsFemale { get; set; }
    }
}