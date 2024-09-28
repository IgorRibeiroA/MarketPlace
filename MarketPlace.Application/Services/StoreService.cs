using MarketPlace.Application.DTOs;
using MarketPlace.Application.Interfaces;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Interfaces;
using System.Net;


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
                Name = storeDto.Name,
                Description = storeDto.Description,
                Owner = storeDto.Owner,
                Address = storeDto.Address,
                PhoneNumber = storeDto.PhoneNumber,
                Email = storeDto.Email,
                PasswordHash = storeDto.PasswordHash,
                CNPJ = storeDto.CNPJ,
                CreatedAt = storeDto.CreatedAt,
                UpdatedAt = storeDto.UpdatedAt,
                Products = storeDto.Products
            };

            var createdStore = await _storeRepository.CreateStoreAsync(store);
            return new StoreDto
            {
                Id = createdStore.Id,
                Name = createdStore.Name,
                Description = createdStore.Description,
                Owner = createdStore.Owner,
                Address = createdStore.Address,
                PhoneNumber = createdStore.PhoneNumber,
                Email = createdStore.Email,
                PasswordHash = createdStore.PasswordHash,
                CNPJ = createdStore.CNPJ,
                CreatedAt = createdStore.CreatedAt,
                UpdatedAt = createdStore.UpdatedAt,
                Products = createdStore.Products
            };
        }

        public async Task<StoreDto> UpdateStoreAsync(StoreDto storeDto)
        {
            var store = new Store
            {
                Id = storeDto.Id,
                Name = storeDto.Name,
                Description = storeDto.Description,
                Owner = storeDto.Owner,
                Address = storeDto.Address,
                PhoneNumber = storeDto.PhoneNumber,
                Email = storeDto.Email,
                PasswordHash = storeDto.PasswordHash,
                CNPJ = storeDto.CNPJ,
                CreatedAt = storeDto.CreatedAt,
                UpdatedAt = storeDto.UpdatedAt,
                Products = storeDto.Products
            };

            var updatedStore = await _storeRepository.UpdateStoreAsync(store);
            if (updatedStore == null) return null;

            return new StoreDto
            {
                Id = updatedStore.Id,
                Name = updatedStore.Name,
                Description = updatedStore.Description,
                Owner = updatedStore.Owner,
                Address = updatedStore.Address,
                PhoneNumber = updatedStore.PhoneNumber,
                Email = updatedStore.Email,
                PasswordHash = updatedStore.PasswordHash,
                CNPJ = updatedStore.CNPJ,
                CreatedAt = updatedStore.CreatedAt,
                UpdatedAt = updatedStore.UpdatedAt,
                Products = updatedStore.Products
            };
        }

        public async Task<bool> DeleteStoreAsync(int id)
        {
            return await _storeRepository.DeleteStoreAsync(id);
        }
    }
}
