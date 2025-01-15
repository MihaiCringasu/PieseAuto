using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace PieseAuto.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public ICollection<ProductCategory>? ProductCategories { get; set; }

    }
}