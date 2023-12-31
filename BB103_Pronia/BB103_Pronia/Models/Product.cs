﻿namespace BB103_Pronia.Models
{
    public class Product:BaseEntity
    {
        public string  Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string SKU { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
        public List<ProductTag> ProductTags { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
