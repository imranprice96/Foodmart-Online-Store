using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foodmart.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The Department name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a Department name between 3 and 50 characters in length")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Please enter a Deparment name beginning with a capital letter and enter only letters and spaces.")]
        [Display(Name = "Department")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}