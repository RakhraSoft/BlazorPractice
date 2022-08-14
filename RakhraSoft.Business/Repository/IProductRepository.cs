using System;
using RakhraSoft.Models.DTOs;

namespace RakhraSoft.Business.Repository
{
    public interface IProductRepository
    {
        public Task<ProductDTO> CreateAsync(ProductDTO objDTO);
        public Task<ProductDTO> UpdateAsync(ProductDTO objDTO);
        public Task<int> DeleteAsync(int id);
        public Task<ProductDTO> GetAsync(int id);
        public Task<IEnumerable<ProductDTO>> GetAllAsync();
    }
}

