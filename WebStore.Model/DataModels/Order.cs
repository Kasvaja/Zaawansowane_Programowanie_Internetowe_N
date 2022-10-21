using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;


public class Order
{
    [Key]
    public int Id { get; set; }
    public DateTime DeliveryDate { get; set; }
    public DateTime OrderDate { get; set; }
    [NotMapped]
    public decimal TotalAmount => OrderProducts == null ? 0 :
                                  OrderProducts.Sum(op => op.Product != null ? op.Product.Price : 0);
    public long TrackingNumber { get; set; }
    public virtual Invoice Invoice { get; set; } = default!;
    [ForeignKey("Invoice")]
    public int? InvoiceId { get; set; }
    public virtual Customer Customer { get; set; } = default!;
    [ForeignKey("Customer")]
    public int? CustomerId { get; set; }
    public virtual StationaryStore StationaryStore { get; set; } = default!;
    [ForeignKey("StationaryStore")]
    public int? StationaryStoreId { get; set; }
    public virtual IList<OrderProduct> OrderProducts { get; set; } = default!;
}
