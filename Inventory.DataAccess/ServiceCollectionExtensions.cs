using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.DataAccess;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqliteDataAccess(this IServiceCollection services, string sqliteFile)
    {
        return services.AddDbContext<InventoryDbContext>(options => 
        {
            options.UseSqlite(sqliteFile);
        });
    }
}