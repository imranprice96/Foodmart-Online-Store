using Foodmart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Foodmart.ViewModels
{
    public class ProductIndexViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public string Search { get; set; }
        public IEnumerable<DepartmentWithCount> DepsWithCount { get; set; }
        public string Department { get; set; }
        public IEnumerable<SelectListItem> DepFilterItems
        {
            get
            {
                var allDeps = DepsWithCount.Select(dd => new SelectListItem
                {
                    Value = dd.DepartmentName,
                    Text = dd.DepNameWithCount
                });
                return allDeps;
            }
        }
    }
    public class DepartmentWithCount
    {
        public int ProductCount { get; set; }
        public string DepartmentName { get; set; }
        public string DepNameWithCount
        {
            get
            {
                return DepartmentName + " (" + ProductCount.ToString() + ")";
            }
        }
    }
}
