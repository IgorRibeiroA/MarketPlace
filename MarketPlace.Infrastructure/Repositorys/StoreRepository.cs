using Dapper;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Interfaces;
using MarketPlace.Infrastructure.Data;

namespace MarketPlace.Infrastructure.Service
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DapperContext _dapperContext;

        public StoreRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Store>> GetAllStoresAsync()
        {
            using var connection = _dapperContext.CreateConnection();
            var query = "SELECT * FROM Store";
            var stores = await connection.QueryAsync<Store>(query);
            return stores.ToList();
        }

        public async Task<Store> GetStoreByIdAsync(int id)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = "SELECT * FROM Store WHERE Id = @Id";
            var store = await connection.QueryFirstOrDefaultAsync<Store>(query, new { Id = id });
            if (store == null) return null;
            return store;
        }

        public async Task<Store> CreateStoreAsync(Store store)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = "INSERT INTO Store (Name) VALUES (@Name)";
            var id = await connection.ExecuteScalarAsync<int>(query, store);
            store.Id = id;
            return store;
        }

        public async Task<Store> UpdateStoreAsync(Store store)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = "UPDATE Store SET Name = @Name WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, store);
            if (rowsAffected > 0)
            {
                return store;
            }
            return null;
        }

        public async Task<bool> DeleteStoreAsync(int id)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = "DELETE FROM Store WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
