﻿using System.ComponentModel.DataAnnotations;

namespace BB103_Pronia.Areas.Manage.ViewModels.Product
{
    public class UpdateProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? SKU { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        public List<int> TagIds { get; set; }
        public IFormFile? MainPhoto { get; set; }
        public IFormFile? HoverPhoto { get; set; }
        public List<IFormFile>? Photos { get; set; }
        public List<ProductImageVm>? ProductImagesVm { get; set; }
        public List<int>? ImageIds { get; set; }
    }
    public class ProductImageVm
    {
        public int Id { get; set; }
        public bool? IsPrime { get; set; }
        public string ImgUrl { get; set; }
    }

}
