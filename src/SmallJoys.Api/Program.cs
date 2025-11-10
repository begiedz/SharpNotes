using Microsoft.EntityFrameworkCore;
using SmallJoys.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

const string CorsPolicy = "FrontendPolicy";

// Load origins list from current env.
var origins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>() ?? [];

builder.Services.AddCors(origin =>
{
    origin.AddPolicy(CorsPolicy, policy =>
        policy.WithOrigins(origins)
              .AllowAnyMethod()
              .AllowAnyHeader()
    );
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddInfrastructure(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsPolicy);

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SmallJoys.Infrastructure.Data.AppDbContext>();
    await db.Database.MigrateAsync();
}


app.Run();
