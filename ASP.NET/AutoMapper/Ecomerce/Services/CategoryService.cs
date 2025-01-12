using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecomerce.DTOs;
using Ecomerce.Interfaces;
using Ecomerce.Models;

namespace Ecomerce.Services
{
    public class CategoryService : ICategoryService
    {
        private static readonly List<Category> categories = new List<Category>();

        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CategoryReadDto> GetAllCategory()
        {

            return _mapper.Map<List<CategoryReadDto>>(categories);
        }

        public CategoryReadDto? GetCategoryById(Guid id)
        {
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);

            return foundCategory == null ? null : _mapper.Map<CategoryReadDto>(foundCategory);
        }

        public CategoryReadDto CreateCategory(CategoryCreateDto category_data)
        {

            var New_category = _mapper.Map<Category>(category_data);
            New_category.CategoryId = Guid.NewGuid();
            New_category.CreatedAt = DateTime.UtcNow;
            categories.Add(New_category);

            return _mapper.Map<CategoryReadDto>(New_category);
        }

        public CategoryReadDto CreateManual()
        {
            var New_category = new Category
            {
                CategoryId = Guid.Parse("12345678-1234-1234-1234-123456789abc"),
                Name = "C#",
                Description = "This is a type of Programming Language, It used for .NET",
                CreatedAt = DateTime.UtcNow,
            };
            categories.Add(New_category);
            return _mapper.Map<CategoryReadDto>(New_category);
        }

        public CategoryReadDto? CategoryUpdate(Guid id, CategoryUpdateDto category_data)
        {
            Console.WriteLine($"Received PUT request for ID: {id}");

            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
            if (foundCategory == null)
            {
                Console.WriteLine("Category not found.");
                return null;
            }

            _mapper.Map(category_data, foundCategory);

            return _mapper.Map<CategoryReadDto>(foundCategory);
        }

        public bool CategoryDelete(Guid id)
        {
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
            if (foundCategory == null)
            {
                return false;
            }
            categories.Remove(foundCategory);
            return true;
        }
    }
}