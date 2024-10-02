using MarketPlace.Application.DTOs;
using MarketPlace.Application.Interfaces;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Interfaces;

namespace MarketPlace.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(products => new ProductDto
            {
                Id = products.Id,
                Name = products.Name
            }).ToList();
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return null;
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description
            };

            var createdProduct = await _productRepository.CreateProductAsync(product);
            return new ProductDto
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Description = createdProduct.Description

            };
        }
          
        public async Task<ProductDto> UpdateProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description
            };

            var updatedProduct = await _productRepository.UpdateProductAsync(product);
            if (updatedProduct == null) return null;

            return new ProductDto
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Description = updatedProduct.Description   
            };
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }
    }
}
