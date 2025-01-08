//Program.cs
var builder = WebApplication.CreateBuilder(args);

// Add Services to the Controller
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Check the apps working or not
app.MapGet("/", () =>
{
    return "App is working Well!!";
});


// Create a list

// See the initialize situation of list


// Show now the list output by search wise


// Created a Manual array


// create dinamically



// Delete 

// Update

// Mapping
app.MapControllers();

app.Run();


//Catergory Controller.cs
//using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return Ok(categories);
        }

        [HttpPost]

        public IActionResult CreateCategories(Category category_data)
        {
            if (string.IsNullOrEmpty(category_data.Name))
            {
                return BadRequest("Category Name is Required!! Your should give name");
            }

            if (category_data.Name.Length < 2)
            {
                return BadRequest("You Must Enter the name of length is Minimum 3");
            }
            var New_category = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = category_data.Name,
                Description = category_data.Description,
                CreatedAt = DateTime.UtcNow,
            };
            categories.Add(New_category);
            return Created($"/api/categories/{New_category.CategoryId}", New_category);
        }

        [HttpDelete("{id:guid}")]

        public IActionResult DeleteCategories(Guid id)
        {
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
            if (foundCategory == null)
            {
                return NotFound("Category with this ID not found");
            }
            categories.Remove(foundCategory);
            return NoContent();
        }

        [HttpPut("{id:guid}")]

        public IActionResult UpdateCategories(Guid id, Category category_data)
        {
            Console.WriteLine($"Received PUT request for ID: {id}");
            if (category_data == null)
            {
                return BadRequest("Category Data is Missing");
            }

            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
            if (foundCategory == null)
            {
                Console.WriteLine("Category not found.");
                return NotFound("Category with this ID not found");
            }


            if (!string.IsNullOrEmpty(category_data.Name))
            {
                if (category_data.Name.Length > 2)
                {
                    foundCategory.Name = category_data.Name;
                }
                else
                {
                    return BadRequest("You Must Enter the name of length is Minimum 3");
                }

            }

            if (!string.IsNullOrWhiteSpace(category_data.Description))
            {
                foundCategory.Description = category_data.Description;
            }
            return NoContent();
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
            return Created($"/api/categories/{New_category.CategoryId}", New_category);
        }

    }
}



// Ecomerce .http

@Ecomerce_HostAddress = http://localhost:5272

#Check that api is working or not
GET http://localhost:5272
###


#Check That what is the List Initial Situation
GET http://localhost:5272/api/categories
###


#Search Value , There C%23 meand C#
GET http://localhost:5272/api/categories/search?searchValue=C%23
###

#Search Value , 
GET http://localhost:5272/api/categories/search?searchValue=
###


#Create a Manual Data and insert to List
POST http://localhost:5272/api/categories/AddManualData
###


#Pass Manual Data and insert to list
POST http://localhost:5272/api/categories
Content-Type: application/json

{
    "name": "Golang",
    "description": "It is a Type of Programming Language, It's also called Mother Language"
}

###


#Update Data
PUT http://localhost:5272/api/categories/12345678-1234-1234-1234-123456789abc
Content-Type: application/json

{
    "name": "JavaScripts",
    "description": "Its a Type of Programming Language, Which is most popular to Web Development"
}

###


#Delete Data
DELETE http://localhost:5272/api/categories/12345678-1234-1234-1234-123456789abc

###







