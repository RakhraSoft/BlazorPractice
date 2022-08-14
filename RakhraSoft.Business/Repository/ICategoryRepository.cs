using System;
using RakhraSoft.Models.DTOs;

namespace RakhraSoft.Business.Repository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDTO> CreateAsync(CategoryDTO objDTO);
        public Task<CategoryDTO> UpdateAsync(CategoryDTO objDTO);
        public Task<int> DeleteAsync(int id);
        public Task<CategoryDTO> GetAsync(int id);
        public Task<IEnumerable<CategoryDTO>> GetAllAsync();
    }
}

