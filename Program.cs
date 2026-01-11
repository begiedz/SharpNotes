using SharpNotes.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/openapi/v1.json", "SharpNotes v1");
    });
}

app.UseHttpsRedirection();

var notes = new List<Note>
{
    new(1, "First Note", "Example text for the first note.",DateTime.UtcNow.AddDays(-2)),
    new(2, "Second Note", "Lorem ipsum.", DateTime.UtcNow.AddDays(-1)),
    new(3, "Third Note", "I like pizza.")
};

app.MapGet("/api/notes", () =>
{
    return notes;
});

app.Run();
