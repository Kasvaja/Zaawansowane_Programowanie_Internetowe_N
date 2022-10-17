using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;


public class Order
{
   public Customer Customer {get; set;} = default!;
   [ForeignKey("Customer")]
   public int CustomerId { get; set; }
   public DateTime DeliveryDate {get; set;}  
   public int Id {get; set; }
   public DateTime OrderDate {get; set;}
   public decimal TotalAmount {get; set;} 
   public long TrackingNumber {get; set; }
   public Invoice Invoice {get; set; } = default!;
   [ForeignKey("Invoice")]
   public int Invoiceid {get; set;} = default!;
   public IList<OrderProduct> OrderProducts {get; set;} = default!;

}