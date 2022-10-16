using Microsoft.AspNetCore.Identity;
namespace WebStore.Model.DataModel
{
    public class Product
    {
        public Category Category { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Id { get; set; } = default!;
        public byte[] ImageBytes { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public Supplier Supplier { get; set; } = default!;
        public float Weight { get; set; } = default!;

    }
}