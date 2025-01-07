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
app.MapPost("/api/categories", () =>
{
    var New_category = new Category
    {
        CategoryId = Guid.NewGuid(),
        Name = "Electronics",
        Description = "This is a type of Electronics Device",
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
app.MapPut("/api/categories/{id}", (Guid id) =>
{
    Console.WriteLine($"Received PUT request for ID: {id}");

    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
    if (foundCategory == null)
    {
        Console.WriteLine("Category not found.");
        return Results.NotFound("Category with this ID not found");
    }

    Console.WriteLine($"Updating category with ID: {id}");
    foundCategory.Name = "Samsung";
    foundCategory.Description = "This is a type of Android Phone";
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
