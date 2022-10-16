namespace WebStore.Model.DataModel;

public class Address
{
    public string PostalCode { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string Street { get; set; } = default!;
}