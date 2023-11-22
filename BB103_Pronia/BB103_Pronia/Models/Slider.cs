using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BB103_Pronia.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [StringLength(maximumLength:10,ErrorMessage ="Uzunlugu maxsimum 10 olara biler")]
        public string SubTitle { get; set; }
        public string Description { get; set; }
        [StringLength(maximumLength:100)]
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
