namespace PieseAuto.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Book Product { get; set; }
        public int CategoryID { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; }
    }
}
