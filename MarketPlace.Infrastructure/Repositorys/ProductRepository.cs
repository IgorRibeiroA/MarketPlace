using Dapper;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Interfaces;
using MarketPlace.Infrastructure.Data;

namespace MarketPlace.Infrastructure.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _dapperContext;

        public ProductRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            using var connection = _dapperContext.CreateConnection();
            var query = "SELECT * FROM Product";
            var products = await connection.QueryAsync<Product>(query);
            return products.ToList();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = "SELECT * FROM Product WHERE Id = @Id";
            var product = await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
            if (product == null) return null;
            return product;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = @"
                          INSERT INTO Product (Name, Description, Price, Quantity, StoreId, Category, CreatedAt, UpdatedAt)
                          VALUES (@Name, @Description, @Price, @Quantity, @StoreId, @Category, @CreatedAt, @UpdatedAt);";
            var id = await connection.ExecuteScalarAsync<int>(query, product);
            product.Id = id;
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = @"
                          UPDATE Product 
                          SET Name = @Name, 
                          Description = @Description, 
                          Price = @Price,
                          Quantity = @Quantity,
                          StoreId = @StoreId,
                          Category = @Category.
                          CreatedAt = @CreatedAt,
                          UpdatedAt = @UpdatedAt 
                          WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, product);
            if (rowsAffected > 0)
            {
                return product;
            }
            return null;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = "DELETE FROM Product WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
