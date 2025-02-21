namespace DBOperationWithEFCoreApp.Data.Model;

public class Sale
{
    public required string ProductName { get; init; }
    public int QuantitySold { get; init; }
    public DateTime SaleDate { get; init; }
}

