using SharpNotes.Models;
using SharpNotes.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Missing ConnectionString: Default");

builder.Services.AddSingleton(new DbConn(connectionString));

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


app.MapGet("/api/notes", (DbConn db) =>
{
    using var conn = db.Open();
    using var cmd = conn.CreateCommand();
    cmd.CommandText = "SELECT Id, Title, Content, CreatedAt FROM Notes";
    using var reader = cmd.ExecuteReader();

    var notes = new List<Note>();
    while (reader.Read())
        notes.Add(new Note(
            (uint)reader.GetInt32(0),
            reader.GetString(1),
            reader.GetString(2),
            reader.GetDateTime(3)
        ));
    return notes;
});

app.MapPost("/api/notes", (DbConn db, CreateNote body) =>
{
    using var conn = db.Open();
    using var cmd = conn.CreateCommand();
    cmd.CommandText = """
    INSERT INTO Notes (Title,Content, CreatedAt)
    VALUES ($title, $content, datetime('now'));

    SELECT last_insert_rowid();
    """;
    cmd.Parameters.AddWithValue("$title", body.Title.Trim());
    cmd.Parameters.AddWithValue("$content", body.Content.Trim());

    using var r = cmd.ExecuteReader();
    r.Read();

    var note = new Note(
        (uint)r.GetInt32(0),
        r.GetString(1),
        r.GetString(2),
        DateTime.Parse(r.GetString(3))
    );

    var id = (uint)(long)cmd.ExecuteScalar()!;
    return Results.Created($"/api/notes/{note.Id}", note);
});

app.Run();
