var builder = WebApplication.CreateBuilder(args);


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
List<Category> categories = new List<Category>();

// Show now the array present situation
app.MapGet("/api/categories", () =>
{
    return Results.Ok(categories);
});

// Created a Manual array
app.MapPost("/api/categories/AddManualData", () =>
{
    var New_category = new Category
    {
        CategoryId = Guid.Parse("12345678-1234-1234-1234-123456789abc"),
        Name = "Electronics",
        Description = "This is a type of Electronics Device",
        CreatedAt = DateTime.UtcNow,
    };
    categories.Add(New_category);
    return Results.Created($"/api/categories/{New_category.CategoryId}", New_category);
});

// create dinamically
app.MapPost("/api/categories", (Category category_data) =>
{

    var New_category = new Category
    {
        CategoryId = Guid.NewGuid(),
        Name = category_data.Name,
        Description = category_data.Description,
        CreatedAt = DateTime.UtcNow,
    };
    categories.Add(New_category);
    return Results.Created($"/api/categories/{New_category.CategoryId}", New_category);
});


// Delete 
app.MapDelete("/api/categories/{id}", (Guid id) =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
    if (foundCategory == null)
    {
        return Results.NotFound("Category with this ID not found");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});


// Update
app.MapPut("/api/categories/{id}", (Guid id, Category category_data) =>
{
    Console.WriteLine($"Received PUT request for ID: {id}");

    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
    if (foundCategory == null)
    {
        Console.WriteLine("Category not found.");
        return Results.NotFound("Category with this ID not found");
    }

    Console.WriteLine($"Updating category with ID: {id}");
    foundCategory.Name = category_data.Name;
    foundCategory.Description = category_data.Description;
    return Results.NoContent();
});


app.Run();

public record Category
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}



// API Calling System 
// Using Rest Client Api testing
@Ecomerce_HostAddress = http://localhost:5272

#Check that api is working or not
GET http://localhost:5272
###


#Check That what is the List Initial Situation
GET http://localhost:5272/api/categories
###


#Create a Manual Data and insert to List
POST http://localhost:5272/api/categories/AddManualData
###


#Pass Manual Data and insert to list
POST http://localhost:5272/api/categories
Content-Type: application/json

{
    "name": "Software",
    "description": "It is a type of software"
}

###


#Update Data
PUT http://localhost:5272/api/categories/12345678-1234-1234-1234-123456789abc
Content-Type: application/json

{
    "name": "Samsung",
    "description": "It is a type of Android Phone"
}

###


#Delete Data
DELETE http://localhost:5272/api/categories/12345678-1234-1234-1234-123456789abc

###
