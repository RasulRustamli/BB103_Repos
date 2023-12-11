using System;

namespace BB103_Pronia.Models
{
    public class Order:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public bool? Status { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public double TotalPrice { get; set; }
    }
}
