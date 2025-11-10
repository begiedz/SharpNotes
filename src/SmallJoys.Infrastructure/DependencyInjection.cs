using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmallJoys.Application.Abstractions;
using SmallJoys.Infrastructure.Data;
using SmallJoys.Infrastructure.Repositories;

namespace SmallJoys.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var conn = configuration.GetConnectionString("Default");
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(conn));
        services.AddScoped<IJoyRepository, JoyRepository>();
        return services;
    }
}
