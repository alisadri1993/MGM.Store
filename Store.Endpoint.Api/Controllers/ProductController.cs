using Microsoft.AspNetCore.Mvc;
using Store.Business.DI;
using Store.Business.Services;
using Store.Shared.Dto;

namespace Store.Endpoint.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]/")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }


        [HttpGet("say")]
        public string saySalam()
        {
            return "Salaaaaam".toMGMString(); // extention method
        }

        [HttpGet("id")]
        public string getProduct(int id)
        {
            return "p"+id;
        }

        [HttpGet("{id}/detail")]
        public string getProduct2(int id)
        {
            return "p"+id;
        }

        [HttpGet("{id:int}/info")]
        public string getProduct3([FromRoute]int id)
        {
            return "p"+id;
        }

        //----------------------------------------------------------------------------------------------

        [HttpGet("all")]
        public async Task<List<ProductDto>> GetAllProduct([FromQuery]ProductRequest request)
        {
            return await productService.GetAllAsync(request);
        }

        [HttpPost("add")]
        public async Task<Guid> Create(ProductDto product)
        {
            logger.LogInformation($"product created by name = {product.name}");
            return await productService.CreateAsync(product);
        }

        [HttpPost("getById")]
        public async Task<ProductDto> gGetById(Guid id)
        {
            return await productService.GetByIdAsync(id);
        }



    }
}
