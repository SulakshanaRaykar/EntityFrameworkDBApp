namespace DBOperationWithEFCoreApp.Data
{
    public class Book
    {
        // Properties
        public int Id  { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NoOfPages { get; set; }
        public bool ISActive { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }

    }
}
