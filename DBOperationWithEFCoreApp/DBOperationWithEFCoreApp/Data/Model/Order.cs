namespace DBOperationWithEFCoreApp.Data.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> Products { get; set; }
    }
}
