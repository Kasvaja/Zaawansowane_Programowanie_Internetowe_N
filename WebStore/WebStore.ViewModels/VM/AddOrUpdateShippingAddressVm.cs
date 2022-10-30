namespace WebStore.ViewModels.VM;
public class AddOrUpdateShippingAddressVm
{
    public int? Id { get; set; }
    public int CustomerId { get; set; }
    public string City { get; set; } = default!;
    public string StreetName { get; set; } = default!;
    public int StreetNumber { get; set; } = default!;
    public string PostCode { get; set; } = default!;
}
