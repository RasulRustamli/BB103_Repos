
using System.ComponentModel.DataAnnotations;

namespace BB103_Pronia.Models
{
    public class Category:BaseEntity
    {
       
        [Required,StringLength(maximumLength:40,ErrorMessage ="Uzunlugu asdiniz")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
