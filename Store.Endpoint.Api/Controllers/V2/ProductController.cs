using Microsoft.AspNetCore.Mvc;
using Store.Business.DI;
using Store.Business.Services;
using Store.Shared.Dto;
using Store.Shared.Models;

namespace Store.Endpoint.Api.Controllers.V2
{
    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //api/v2/product/add
    
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        /// <summary>
        /// سرویس ثبت مشخصات محصول
        /// </summary>
        /// <param name="product">مشخصات محصول</param>
        /// <returns>شناسه محصول اضافه شده</returns>
        /// 
        [HttpPost("add")]
        public async Task<Guid> Create(ProductDto2 product)
        {
            logger.LogInformation($"product created by name = {product.name}");
            return await productService.CreateAsync(product);
        }

    }
}
