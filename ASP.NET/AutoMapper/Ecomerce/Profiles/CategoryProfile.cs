using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecomerce.DTOs;
using Ecomerce.Models;

namespace Ecomerce.Profiles
{
    public class CategoryProfile:Profile
    {   
        public CategoryProfile() {
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            
        }
        
    }
}