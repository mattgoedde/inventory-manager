using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Inventory.Api;

public static class EdmModelBuilder
{
    public static IEdmModel Build()
    {
        var modelBuilder = new ODataConventionModelBuilder();

        modelBuilder.EntityType<LocationTypeEntity>();
        modelBuilder.EntityType<TagEntity>();
        
        modelBuilder.EntitySet<TenantEntity>("Tenants");
        modelBuilder.EntitySet<LocationEntity>("Locations");
        modelBuilder.EntitySet<TrackedItemEntity>("TrackedItems");
        modelBuilder.EntitySet<UntrackedItemEntity>("UntrackedItems");

        return modelBuilder.GetEdmModel();
    }
}
