//Program.cs
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the Controller

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options => {
    options.InvalidModelStateResponseFactory = context => {
        var errors = context.ModelState.Where(e => e.Value != null && e.Value.Errors.Count > 0)
                .Select(e => new
                {
                    Field = e.Key,
                    Errors = e.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                }).ToList();
        var errorstring = string.Join("; ", errors.Select(e => $"{e.Field} : {string.Join(", ", e.Errors ?? Array.Empty<string>())}"));

        return new BadRequestObjectResult(new {
            Message = "Validation Failed",
            Errors = errorstring
        });
    };
});
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