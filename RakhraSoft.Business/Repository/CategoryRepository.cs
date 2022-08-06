using AutoMapper;
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

        public CategoryDTO Create(CategoryDTO objDTO)
        {
            var category = mapper.Map<CategoryDTO, Category>(objDTO);
            category.CreatedDate = DateTime.Now;
            var added = applicationDbContext.Categories.Add(category);
            applicationDbContext.SaveChanges();

            return mapper.Map<Category, CategoryDTO>(added.Entity);
        }

        public int Delete(int id)
        {
            var obj = applicationDbContext.Categories.FirstOrDefault(u => u.Id == id);
            if (obj is null)
            {
                return 0;
            }

            applicationDbContext.Categories.Remove(obj);
            return applicationDbContext.SaveChanges();
        }

        public CategoryDTO Get(int id)
        {
            var obj = applicationDbContext.Categories.FirstOrDefault(u => u.Id == id);
            if (obj is null)
            {
                return new CategoryDTO();
            }

            return mapper.Map<Category, CategoryDTO>(obj);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(applicationDbContext.Categories);
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            var objFromDb = applicationDbContext.Categories.FirstOrDefault(u => u.Id == objDTO.Id);
            if (objFromDb is null)
            {
                return objDTO;
            }

            objFromDb.Name = objDTO.Name;
            applicationDbContext.Categories.Update(objFromDb);
            applicationDbContext.SaveChanges();
            return mapper.Map<Category, CategoryDTO>(objFromDb);
        }
    }
}

