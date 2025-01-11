//using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomerce.DTOs;
using Ecomerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [ApiController]
    [Route("api/categories/")]



    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();



        [HttpGet]

        public IActionResult GetCategories()
        {
            var CategoryList = categories.Select(c => new CategoryReadDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                //CreatedAt = c.CreatedAt
            }).ToList();

            return Ok(ApiResponse<List<CategoryReadDto>>.SuccessResponse(CategoryList, 200, "Category Returned Successfully"));
        }



        [HttpPost]

        public IActionResult CreateCategories(CategoryCreateDto category_data)
        {

            var New_category = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = category_data.Name,
                Description = category_data.Description,
                CreatedAt = DateTime.UtcNow,
            };
            categories.Add(New_category);

            var CategoryList = new CategoryReadDto
            {
                CategoryId = New_category.CategoryId,
                Name = New_category.Name,
                Description = New_category.Description,
                //CreatedAt = c.CreatedAt
            };
            return Created($"/api/categories/{New_category.CategoryId}", ApiResponse<CategoryReadDto>.SuccessResponse(CategoryList, 201, "Category Created Successfully"));
        }





        [HttpDelete("{id:guid}")]

        public IActionResult DeleteCategories(Guid id)
        {
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
            if (foundCategory == null)
            {
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> { "Category id doesn't Exits" }, 400, "Validation Failed"));
            }
            categories.Remove(foundCategory);
            return Ok(ApiResponse<object>.SuccessResponse(null, 204, "Category Deleted Successfully"));
        }





        [HttpPut("{id:guid}")]

        public IActionResult UpdateCategories(Guid id, CategoryUpdateDto category_data)
        {
            Console.WriteLine($"Received PUT request for ID: {id}");

            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
            if (foundCategory == null)
            {
                Console.WriteLine("Category not found.");
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> { "Category is not found with this ID" }, 400, "Validation Failed"));
            }

            foundCategory.Name = category_data.Name;
            foundCategory.Description = category_data.Description;

            return Ok(ApiResponse<object>.SuccessResponse(null, 204, "Update Category Successfully"));
        }





        [HttpGet("search")]
        public IActionResult SearchCategories(string searchValue = "")
        {
            //Console.WriteLine($"{searchValue}");
            if (!string.IsNullOrEmpty(searchValue))
            {
                var new_category = categories
                    .Where(c => !string.IsNullOrEmpty(c.Name) && c.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                if (new_category.Any()) return Ok(new_category);
                else return NotFound($"No categories found matching '{searchValue}'.");
            }
            return Ok(categories);
        }

        [HttpPost("AddManualData")]

        public IActionResult CreateManual()
        {
            var New_category = new Category
            {
                CategoryId = Guid.Parse("12345678-1234-1234-1234-123456789abc"),
                Name = "C#",
                Description = "This is a type of Programming Language, It used for .NET",
                CreatedAt = DateTime.UtcNow,
            };
            categories.Add(New_category);
            var CategoryList = new CategoryReadDto
            {
                CategoryId = New_category.CategoryId,
                Name = New_category.Name,
                Description = New_category.Description,
                //CreatedAt = c.CreatedAt
            };

            return Created($"/api/categories/{New_category.CategoryId}", ApiResponse<CategoryReadDto>.SuccessResponse(CategoryList, 201, "Category Created Successfully"));
        }

    }
}