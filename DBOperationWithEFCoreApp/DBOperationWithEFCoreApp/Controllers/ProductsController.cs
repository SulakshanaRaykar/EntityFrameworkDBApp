using Microsoft.AspNetCore.Mvc;
using DBOperationWithEFCoreApp.Interfaces;

namespace DBOperationWithEFCoreApp.Data.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
           
        }

        [HttpGet("monthlyorder")]
        public IActionResult GetProductMonthlyOrders()
        {
            try
            {
                return Ok(_productService.GetProductMonthlyOrders());
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet("customers/segment")]
        public IActionResult GetCustomerSegment()
        {
            try
            {
                return Ok(_productService.GetCustomerSegment());
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet("quarterlyTotalRevenue")]
        public IActionResult GetQuarterWiseSoldProductQuantity()
        {
            try
            {
                return Ok(_productService.GetQuarterWiseSoldProductQuantity());
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet("newid")]
        public IActionResult GetNewProductID()
        {
            try
            {
                var id1 = _productService.GetDynamicProductID();
                var id2 = _productService.GetDynamicProductID();



                return Ok(_productService.GetDynamicProductID());
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }

            [HttpGet]
            public async Task<IActionResult> GetProducts(int pageNumber = 1, int pageSize = 10)
            {
                var paginatedProducts = await _productService.GetPaginatedProducts(pageNumber, pageSize);
                return Ok(paginatedProducts);
            }
        
    }
}
