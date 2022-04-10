﻿using Microsoft.Extensions.Logging;
using Store.Business.Entities;
using Store.Business.Interfaces;
using Store.Shared.Dto;

namespace Store.Business.Services;
public class ProductService : IProductService
{
    private readonly ILogger<ProductService> logger;
    private readonly IProductRepository _productRepository;

    public ProductService(ILogger<ProductService> logger,IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        _productRepository = productRepository;
    }

    //public static List<Product> products = new();

    public async Task<int> CreateAsync(ProductDto dto)
    {
        Product product = new()
        {
            name = dto.name,
            qty = dto.qty,
            price = dto.price
        };

        //products.Add(product);
        //var permission = _productRepository.ChekUserPermission("");
        //if (permission == null) creator = "admin";

        //unitOfWork._productRepository.save()
        //var temp = await _StockRepository.save(productId, quntity);
        var pId = await _productRepository.Save(product);
        
        return pId;
    }

    public Task<Guid> CreateAsync(ProductDto2 dto)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductDto>> GetAllAsync(ProductRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    /*
        public async Task<List<ProductDto>> GetAllAsync(ProductRequest request)
        {
            return products.Where(p => p.name.Contains(request.name)).Skip(request.offset).Take(request.limit).Select(p => new ProductDto
            {
                name = p.name,
                qty = p.qty,
                price = p.price
            }).ToList();
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = products.Where(p => p.id == id).FirstOrDefault();
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

        public async Task<Guid> CreateAsync(ProductDto2 dto)
        {
            Product product = new();
            product.name = dto.name;
            product.qty = dto.qty;
            product.price = dto.price;
            product.description = dto.description;
            product.id = Guid.NewGuid();

            products.Add(product);

            return product.id;
        }*/
}

