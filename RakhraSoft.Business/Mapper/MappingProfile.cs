using System;
using AutoMapper;
using RakhraSoft.Data;
using RakhraSoft.Models.DTOs;

namespace RakhraSoft.Business.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}

