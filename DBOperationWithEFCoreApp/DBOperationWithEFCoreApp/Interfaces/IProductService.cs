using DBOperationWithEFCoreApp.Data.Model;
using DBOperationWithEFCoreApp.Interfaces;

namespace DBOperationWithEFCoreApp.Interfaces
{
    public interface IProductService
    {
        dynamic GetProductMonthlyOrders();

        dynamic GetCustomerSegment();

        dynamic GetQuarterWiseSoldProductQuantity();
        dynamic GetDynamicProductID();

        Task<Pagination<Order>> GetPaginatedProducts(int pageNumber, int pageSize);
    }
}
