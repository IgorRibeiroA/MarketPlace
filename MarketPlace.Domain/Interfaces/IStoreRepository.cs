using MarketPlace.Domain.Entities; 

namespace MarketPlace.Domain.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStoresAsync();
        Task<Store> GetStoreByIdAsync(int id);
        Task<Store> CreateStoreAsync(Store store);
        Task<Store> UpdateStoreAsync(Store store);
        Task<bool> DeleteStoreAsync(int id);
    }
}