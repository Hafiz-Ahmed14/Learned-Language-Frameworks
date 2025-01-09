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