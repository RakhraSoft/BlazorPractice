using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RakhraSoft.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool ShowFavorites { get; set; }
        public bool CustomerFavorites { get; set; }
        public string Color { get; set; }
        public string TargetUrl { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(name:"CategoryId")]
        public Category Category { get; set; }
    }
}

