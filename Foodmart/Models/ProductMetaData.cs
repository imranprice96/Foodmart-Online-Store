using System.ComponentModel.DataAnnotations;

namespace Foodmart.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    public class ProductMetaData
    {
        [Display(Name = "Product Name")]
        public string Name;
    }
}