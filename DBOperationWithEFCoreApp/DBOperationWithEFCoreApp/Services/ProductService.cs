using DBOperationWithEFCoreApp.Data;
using DBOperationWithEFCoreApp.Interfaces;
using DBOperationWithEFCoreApp.Data.Model;

namespace DBOperationWithEFCoreApp.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;   
        }
        public dynamic GetCustomerSegment()
        {
            var purchases = _context.Purchase.ToList();
            var result = purchases.GroupBy(p => p.CustomerId)
                .Select(p => new
                {
                    CutomerId = p.Key,
                    Segment = GetSegment(p.Sum(x => x.Amount))
                }).ToList();
            return result;
        }

        private string GetSegment(double amount)
        {
            return amount > 10000 ? "Gold" : amount > 5000 && amount < 10000 ? "Silver" : amount < 5000 ? "Bronze" : "No Segment";


        }

        public dynamic GetProductMonthlyOrders()
        {
            try
            {
                var orders =_context.Order.ToList();
                var result = orders.SelectMany(orders => orders.Products, (order, product) => new
                {
                    Pid = product.ProductID,
                    PName = product.Name,
                    Month = order.OrderDate.ToString("MMMM")
                })
                .GroupBy(x => new { x.Pid, x.PName })
                .Select(g => new
                {
                    ProductID = g.Key.Pid,
                    Name = g.Key.PName,
                    MonthlyOrders = string.Join(",", g.GroupBy(x => x.Month).Select(m => $"{m.Key}-{m.Count()}"))

                }).ToList();
                return result;
            }
            catch
            {
                // Log Exception

                throw;
            }
        }
     

       
        public dynamic GetQuarterWiseSoldProductQuantity()
        {
            var monthlySales = _context.Sale.ToList();
            var quarters = new Dictionary<int, int[]>()
            {
                {1,[1,2,3] },{2,[4,5,6] },{3,[7,8,9] },{4,[10,11,12] }
            };
            var res = quarters.Select(quarter => new
            {
                Quarter = quarter.Key,
                TotalRevenue = monthlySales.Where(m => quarter.Value.Contains(m.SaleDate.Month)).Sum(x => x.QuantitySold)
            }).ToList();


            var result = quarters.Select(quarter => new
            {
                Quarter = quarter.Key,
                TotalRevenue = monthlySales.Where(x => quarter.Value.Contains(x.SaleDate.Month)).Sum(x => x.QuantitySold)
            }).ToList();
            return result;
        }

        public dynamic GetDynamicProductID()
        {
            Guid id = Guid.NewGuid();
            return id;

        }


        public async Task<Pagination<Order>> GetPaginatedProducts(int pageNumber, int pageSize)
        {
            try
            {


                var product = _context.Order.AsQueryable();
                return await product.ToPagedAsync(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw;
            }

            
        }
    }
}
