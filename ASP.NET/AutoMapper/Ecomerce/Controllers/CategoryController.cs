//using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomerce.DTOs;
using Ecomerce.Interfaces;
using Ecomerce.Models;
using Ecomerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [ApiController]
    [Route("api/categories/")]



    public class CategoryController : ControllerBase
    {   

        public ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }
        

        [HttpGet]

        public IActionResult GetCategories()
        {
            var CategoryList = _categoryService.GetAllCategory();

            return Ok(ApiResponse<List<CategoryReadDto>>.SuccessResponse(CategoryList, 200, "Category Returned Successfully"));
        }


        //Get Category By ID
        [HttpGet("{id:guid}")]

        public IActionResult GetCategoriesById(Guid id)
        {
            var CategoryList = _categoryService.GetCategoryById(id);

            if (CategoryList == null)
            {
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> { "Category is not found with this ID" }, 400, "Validation Failed"));
            }

            return Ok(ApiResponse<CategoryReadDto>.SuccessResponse(CategoryList, 200, "Category Returned Successfully"));
        }



        [HttpPost]

        public IActionResult CreateCategories(CategoryCreateDto category_data)
        {

            var CategoryList = _categoryService.CreateCategory(category_data);
            return Created(nameof(GetCategoriesById), ApiResponse<CategoryReadDto>.SuccessResponse(CategoryList, 201, "Category Created Successfully"));
        }





        [HttpPut("{id:guid}")]

        public IActionResult UpdateCategories(Guid id, CategoryUpdateDto category_data)
        {   
            var UpdateCategory = _categoryService.CategoryUpdate(id, category_data);
            if (UpdateCategory == null)
            {
                Console.WriteLine("Category not found.");
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> { "Category is not found with this ID" }, 400, "Validation Failed"));
            }
            return Ok(ApiResponse<CategoryReadDto>.SuccessResponse(UpdateCategory, 204, "Update Category Successfully"));
        }



        [HttpDelete("{id:guid}")]

        public IActionResult DeleteCategories(Guid id)
        {
            var foundCategory = _categoryService.CategoryDelete(id);
            if (!foundCategory)
            {
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> { "Category id doesn't Exits" }, 400, "Validation Failed"));
            }
            
            return Ok(ApiResponse<object>.SuccessResponse(foundCategory, 204, "Category Deleted Successfully"));
        }



        // [HttpGet("search")]
        // public IActionResult SearchCategories(string searchValue = "")
        // {
        //     //Console.WriteLine($"{searchValue}");
        //     if (!string.IsNullOrEmpty(searchValue))
        //     {
        //         var new_category = categories
        //             .Where(c => !string.IsNullOrEmpty(c.Name) && c.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
        //             .ToList();
        //         if (new_category.Any()) return Ok(new_category);
        //         else return NotFound($"No categories found matching '{searchValue}'.");
        //     }
        //     return Ok(categories);
        // }

        [HttpPost("AddManualData")]

        public IActionResult CreateManual()
        {
            
            var CategoryList = _categoryService.CreateManual();

            return Created($"/api/categories/{CategoryList.CategoryId}", ApiResponse<CategoryReadDto>.SuccessResponse(CategoryList, 201, "Category Created Successfully"));
        }

    }
}