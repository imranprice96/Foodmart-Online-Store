using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foodmart.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Display(Name = "Department")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}