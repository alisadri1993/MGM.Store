using Microsoft.Extensions.Logging;
using Store.Business.Entities;
using Store.Shared.Dto;

namespace Store.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> logger;

        public ProductService(ILogger<ProductService> logger)
        {
            this.logger = logger;
        }

        public static List<Product> products = new();

        public async Task<Guid> CreateAsync(ProductDto dto)
        {
            Product product = new Product();
            product.name = dto.name;
            product.qty = dto.qty;
            product.price = dto.price;
            product.id = Guid.NewGuid();

            products.Add(product);

            return product.id;
        }


        public async Task<List<ProductDto>> GetAllAsync(ProductRequest request)
        {
            return products.Where(p=>p.name.Contains(request.name)).Skip(request.offset).Take(request.limit).Select(p=>new ProductDto
            {
                name = p.name,
                qty = p.qty,
                price = p.price
            }).ToList();
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = products.Where(p=>p.id == id).FirstOrDefault();
            if (product == null)
            {
                logger.LogWarning($"Product with id {id} not exist!");
            }
            return new ProductDto
            {
                name = product.name,
                qty = product.qty,
                price = product.price
            };
        }
    }
}
