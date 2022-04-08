using System.ComponentModel.DataAnnotations.Schema;
namespace WorkingWithEFCore
{
    public class Category
    {
        // All the properties map the table Category
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
        // defines a navigation property for related rows from other tables
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
        }
        
    }
}