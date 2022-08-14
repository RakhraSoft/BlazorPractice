using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RakhraSoft.Data;
using RakhraSoft.Data.Data;
using RakhraSoft.Models.DTOs;

namespace RakhraSoft.Business.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        public ProductRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO objDTO)
        {
            var product = mapper.Map<ProductDTO, Product>(objDTO);
            var added = applicationDbContext.Products.Add(product);
            await applicationDbContext.SaveChangesAsync();

            return mapper.Map<Product, ProductDTO>(added.Entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var obj = await applicationDbContext.Products.FirstOrDefaultAsync(u => u.Id == id);
            if (obj is null)
            {
                return 0;
            }

            applicationDbContext.Products.Remove(obj);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            var obj = await applicationDbContext.Products.Include(i =>i.Category).FirstOrDefaultAsync(u => u.Id == id);
            if (obj is null)
            {
                return new ProductDTO();
            }

            return mapper.Map<Product, ProductDTO>(obj);
        }

        public Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            return Task.FromResult(mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(applicationDbContext.Products.Include(i => i.Category)));
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO objDTO)
        {
            var objFromDb = await applicationDbContext.Products.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb is null)
            {
                return objDTO;
            }

            objFromDb.Name = objDTO.Name;
            objFromDb.CategoryId = objDTO.CategoryId;
            objFromDb.Color = objDTO.Color;
            objFromDb.CustomerFavorites = objDTO.CustomerFavorites;
            objFromDb.Description = objDTO.Description;
            objFromDb.ShowFavorites = objDTO.ShowFavorites;
            objFromDb.TargetUrl = objDTO.TargetUrl;
            
            applicationDbContext.Products.Update(objFromDb);
            await applicationDbContext.SaveChangesAsync();
            return mapper.Map<Product, ProductDTO>(objFromDb);
        }
    }
}

