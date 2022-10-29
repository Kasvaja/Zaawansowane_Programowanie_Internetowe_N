namespace WebStore.Model.Models;

public class OrderProduct
{
    public virtual Order Order {get; set;} = default!;
    public virtual Product Product {get; set;} = default!;
    public int Quantity {get; set;} = default!;
}