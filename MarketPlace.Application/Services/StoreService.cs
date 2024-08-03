using MarketPlace.Application.DTOs;
using MarketPlace.Application.Interfaces;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Interfaces;


namespace MarketPlace.Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<IEnumerable<StoreDto>> GetAllStoresAsync()
        {
            var stores = await _storeRepository.GetAllStoresAsync();
            return stores.Select(store => new StoreDto
            {
                Id = store.Id,
                Name = store.Name
            }).ToList();
        }

        public async Task<StoreDto> GetStoreByIdAsync(int id)
        {
            var store = await _storeRepository.GetStoreByIdAsync(id);
            if (store == null) return null;
            return new StoreDto
            {
                Id = store.Id,
                Name = store.Name
            };
        }

        public async Task<StoreDto> CreateStoreAsync(StoreDto storeDto)
        {
            var store = new Store
            {
                Name = storeDto.Name
            };

            var createdStore = await _storeRepository.CreateStoreAsync(store);
            return new StoreDto
            {
                Id = createdStore.Id,
                Name = createdStore.Name
            };
        }

        public async Task<StoreDto> UpdateStoreAsync(StoreDto storeDto)
        {
            var store = new Store
            {
                Id = storeDto.Id,
                Name = storeDto.Name
            };

            var updatedStore = await _storeRepository.UpdateStoreAsync(store);
            if (updatedStore == null) return null;

            return new StoreDto
            {
                Id = updatedStore.Id,
                Name = updatedStore.Name
            };
        }

        public async Task<bool> DeleteStoreAsync(int id)
        {
            return await _storeRepository.DeleteStoreAsync(id);
        }
    }
}
