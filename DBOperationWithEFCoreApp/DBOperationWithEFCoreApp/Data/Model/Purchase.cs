namespace DBOperationWithEFCoreApp.Data.Model;


public class Purchase
{
    public string CustomerId { get; init; } = "Unknown";
    public double Amount { get; init; } = 0.0;
    public DateTime PurchaseDate { get; init; } = DateTime.Now;
}