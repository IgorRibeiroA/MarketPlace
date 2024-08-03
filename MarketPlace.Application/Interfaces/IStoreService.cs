using MarketPlace.Application.DTOs;

namespace MarketPlace.Application.Interfaces
{
    public interface IStoreService
    {
        Task<IEnumerable<StoreDto>> GetAllStoresAsync();
        Task<StoreDto> GetStoreByIdAsync(int id);
        Task<StoreDto> CreateStoreAsync(StoreDto storeDto);
        Task<StoreDto> UpdateStoreAsync(StoreDto storeDto);
        Task<bool> DeleteStoreAsync(int id);
    }
}
