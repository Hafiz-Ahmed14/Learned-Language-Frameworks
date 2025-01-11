using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomerce.DTOs;
using Ecomerce.Interfaces;
using Ecomerce.Models;

namespace Ecomerce.Services
{
    public class CategoryService:ICategoryService
    {
        private static readonly List<Category> categories = new List<Category>();

        public List<CategoryReadDto> GetAllCategory() {
             return  categories.Select(c => new CategoryReadDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                //CreatedAt = c.CreatedAt
            }).ToList();
        }

        public CategoryReadDto? GetCategoryById(Guid id) {
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
            if (foundCategory == null)
            {
                return null;
            }
            return new CategoryReadDto
            {
                CategoryId = foundCategory.CategoryId,
                Name = foundCategory.Name,
                Description = foundCategory.Description,
                //CreatedAt = foundCategory.CreatedAt
            };
        }

        public CategoryReadDto CreateCategory(CategoryCreateDto category_data) {
             var New_category = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = category_data.Name,
                Description = category_data.Description,
                CreatedAt = DateTime.UtcNow,
            };
            categories.Add(New_category);

            return new CategoryReadDto
            {
                CategoryId = New_category.CategoryId,
                Name = New_category.Name,
                Description = New_category.Description,
                //CreatedAt = c.CreatedAt
            };
        }

        public CategoryReadDto CreateManual() {
            var New_category = new Category
            {
                CategoryId = Guid.Parse("12345678-1234-1234-1234-123456789abc"),
                Name = "C#",
                Description = "This is a type of Programming Language, It used for .NET",
                CreatedAt = DateTime.UtcNow,
            };
            categories.Add(New_category);
            return new CategoryReadDto
            {
                CategoryId = New_category.CategoryId,
                Name = New_category.Name,
                Description = New_category.Description,
                //CreatedAt = c.CreatedAt
            };
        }

        public CategoryReadDto? CategoryUpdate(Guid id, CategoryUpdateDto category_data) {
             Console.WriteLine($"Received PUT request for ID: {id}");

            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
            if (foundCategory == null)
            {
                Console.WriteLine("Category not found.");
                return null;
            }

            foundCategory.Name = category_data.Name;
            foundCategory.Description = category_data.Description;

            return new CategoryReadDto {
                CategoryId = foundCategory.CategoryId,
                Name = foundCategory.Name,
                Description = foundCategory.Description
            };
        }

        public bool  CategoryDelete(Guid id) {
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