namespace BB103_Pronia.Models
{
    public class ProductImage : BaseEntity
    {
       
        public bool? IsPrime { get; set; }
        public string  ImgUrl { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
