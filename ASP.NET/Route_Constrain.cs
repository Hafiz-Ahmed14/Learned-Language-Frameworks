// Delete 

// only received int value
app.MapDelete("/api/categories/{id:int}", (Guid id) =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
    if (foundCategory == null)
    {
        return Results.NotFound("Category with this ID not found");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});

// only received string value
app.MapDelete("/api/categories/{id:string}", (Guid id) =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
    if (foundCategory == null)
    {
        return Results.NotFound("Category with this ID not found");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});

// only received alpha value
app.MapDelete("/api/categories/{id:alpha}", (Guid id) =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
    if (foundCategory == null)
    {
        return Results.NotFound("Category with this ID not found");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});

// only received guid value
app.MapDelete("/api/categories/{id:guid}", (Guid id) =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
    if (foundCategory == null)
    {
        return Results.NotFound("Category with this ID not found");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});


// only received minimum range values
app.MapDelete("/api/categories/{id:minlength(20)}", (Guid id) =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
    if (foundCategory == null)
    {
        return Results.NotFound("Category with this ID not found");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});


// only received this range value
app.MapDelete("/api/categories/{id:range(1, 100)}", (Guid id) =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
    if (foundCategory == null)
    {
        return Results.NotFound("Category with this ID not found");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});


// only received this email
app.MapDelete("/api/categories/{email:regex()}", (Guid id) =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == id);
    if (foundCategory == null)
    {
        return Results.NotFound("Category with this ID not found");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});
