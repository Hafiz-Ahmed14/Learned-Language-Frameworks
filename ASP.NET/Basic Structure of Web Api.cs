// Basic of API Create
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.UseHttpsRedirection();
app.MapGet("/hello", () =>
{
    return "Hello";
});

app.MapGet("/hafiz", () =>
{
    return "HI am Hafiz";
});
app.Run();
  