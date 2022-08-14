using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RakhraSoft.Data;
using RakhraSoft.Data.Data;
using RakhraSoft.Models.DTOs;

namespace RakhraSoft.Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        public CategoryRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        public async Task<CategoryDTO> CreateAsync(CategoryDTO objDTO)
        {
            var category = mapper.Map<CategoryDTO, Category>(objDTO);
            category.CreatedDate = DateTime.Now;
            var added = applicationDbContext.Categories.Add(category);
            await applicationDbContext.SaveChangesAsync();

            return mapper.Map<Category, CategoryDTO>(added.Entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var obj = await applicationDbContext.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj is null)
            {
                return 0;
            }

            applicationDbContext.Categories.Remove(obj);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<CategoryDTO> GetAsync(int id)
        {
            var obj = await applicationDbContext.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj is null)
            {
                return new CategoryDTO();
            }

            return mapper.Map<Category, CategoryDTO>(obj);
        }

        public Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            return Task.FromResult(mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(applicationDbContext.Categories));
        }

        public async Task<CategoryDTO> UpdateAsync(CategoryDTO objDTO)
        {
            var objFromDb = await applicationDbContext.Categories.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb is null)
            {
                return objDTO;
            }

            objFromDb.Name = objDTO.Name;
            applicationDbContext.Categories.Update(objFromDb);
            await applicationDbContext.SaveChangesAsync();
            return mapper.Map<Category, CategoryDTO>(objFromDb);
        }
    }
}

