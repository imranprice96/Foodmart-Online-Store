namespace Foodmart.Models
{
    public partial class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? DepartmentID { get; set; }
        public virtual Department Department { get; set; }
}
}