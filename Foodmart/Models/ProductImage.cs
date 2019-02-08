using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodmart.Models
{
    public class ProductImage
    {
        public int ID { get; set; }
        [StringLength(100)]
        [Index(IsUnique = true)]
        [Display(Name = "File")]
        public string FileName { get; set; }
        public virtual ICollection<ProductImageMapping> ProductImageMappings { get; set; }
    }
}