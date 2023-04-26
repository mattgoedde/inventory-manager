using AutoMapper;
using Inventory.DataAccess;
using Inventory.Domain.DataTransferObjects;
using Inventory.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Logic.Commands;

public record CreateLocationRequest(Guid TenantId, LocationDto Location) : IRequest<LocationDto?>;
public record GetLocationTreeRequest(Guid TenantId) : IRequest<LocationDto?>;

public class LocationHandler : 
    IRequestHandler<CreateLocationRequest, LocationDto?>,
    IRequestHandler<GetLocationTreeRequest, LocationDto?>
{ 
    private readonly ITenantSecuredDbContextFactory<InventoryDbContext> _dbContextFactory;
    private readonly IMapper _mapper;

    public LocationHandler(ITenantSecuredDbContextFactory<InventoryDbContext> dbContextFactory, IMapper mapper)
    {
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }

    public async Task<LocationDto?> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var newLocationEntity = _mapper.Map<LocationEntity>(request.Location);

        using var context = _dbContextFactory.Create(request.TenantId);

        var newLocationEntry = context.Locations.Add(newLocationEntity);

        await context.SaveChangesAsync();

        return _mapper.Map<LocationDto>(newLocationEntry.Entity);
    }

    public async Task<LocationDto?> Handle(GetLocationTreeRequest request, CancellationToken cancellationToken)
    {
        using var context = _dbContextFactory.Create(request.TenantId);

        var rootLocation = await context.Locations.Include(l => l.ChildLocations).FirstOrDefaultAsync(l => l.ParentLocationId == null && l.Name.Contains("Root") && l.LocationType.Name.Contains("Default"));

        if (rootLocation is null) return null;

        var tree = await RecursiveLocationTreeLoader(rootLocation, context);

        return _mapper.Map<LocationDto>(tree);
    }

    private async Task<LocationEntity> RecursiveLocationTreeLoader(LocationEntity root, InventoryDbContext context)
    {
        if (!root.ChildLocations.Any()) return root;

        foreach (var child in root.ChildLocations)
        {
            var entity = await context.Locations.Include(l => l.ChildLocations).FirstOrDefaultAsync(l => l.Id == child.Id);

        }
    }
}
