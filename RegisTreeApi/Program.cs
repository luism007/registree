using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// adds the database context to the dependency injection (DI) container
builder.Services.AddDbContext<UserDb>(opt => opt.UseInMemoryDatabase("Users"));
// enables displaying database-related exceptions
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();


app.MapGet("/users", async(UserDb db) => await db.Users.ToListAsync());


app.MapPost("/users", async(User user, UserDb db) => {
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

app.MapGet("/", () => "Hello World!");

app.Run();
