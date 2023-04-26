using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Logic;

public class LogicProject { } // this is a dummy class for Mediatr registration

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLogic(this IServiceCollection services)
    {
        return services
            .AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining<LogicProject>();
            })
            .AddAutoMapper(typeof(AutomapperProfile));
    }
}
