using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model.DataModel
{
    public class Product
    {
        // Navigation
        public virtual Category Category { get; set; } = default!;
        [ForeignKey("Category")]
        public int CategoryId { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Id { get; set; }
        public byte[] ImageBytes { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public virtual Supplier Supplier { get; set; } = default!;
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public float Weight { get; set; }


        public virtual IList<ProductStock> ProductStocks { get; set; } = default!;

        public virtual IList<OrderProduct> OrderProducts { get; set; } = default!;

    }
}