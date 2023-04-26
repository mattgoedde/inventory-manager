using AutoMapper;
using Inventory.DataAccess;
using Inventory.Domain.DataTransferObjects;
using Inventory.Domain.Entities;
using MediatR;

namespace Inventory.Logic.Commands;

public record CreateTenantRequest(TenantDto Tenant) : IRequest<TenantDto>;
public record UpsertTenantRequest(TenantDto Tenant) : IRequest<TenantDto>;
public record DeleteTenantRequest(TenantDto Tenant) : IRequest;

public class TenantRequestHandler : 
    IRequestHandler<CreateTenantRequest, TenantDto>,
    IRequestHandler<UpsertTenantRequest, TenantDto>,
    IRequestHandler<DeleteTenantRequest>
{
    private readonly ITenantSecuredDbContextFactory<InventoryDbContext> _dbContextFactory;
    private readonly IMapper _mapper;

    public TenantRequestHandler(ITenantSecuredDbContextFactory<InventoryDbContext> dbContextFactory, IMapper mapper)
    {
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }

    public async Task<TenantDto> Handle(CreateTenantRequest request, CancellationToken cancellationToken)
    {
        var newTenantEntity = _mapper.Map<TenantEntity>(request.Tenant);

        using var context = _dbContextFactory.Create(request.Tenant.Id);

        var newTenantEntry = context.Tenants.Add(newTenantEntity);

        var defaultLocationTypeEntry = context.LocationTypes.Add(new LocationTypeEntity
        {
            Id = Guid.NewGuid(),
            Name = $"{request.Tenant.Name} Default",
            TenantId = request.Tenant.Id,
        });

        context.Locations.Add(new LocationEntity
        {
            Id = Guid.NewGuid(),
            Name = $"{request.Tenant.Name} Root",
            TenantId = request.Tenant.Id,
            ParentLocationId = null,
            LocationTypeId = defaultLocationTypeEntry.Entity.Id
        });

        await context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TenantDto>(newTenantEntity);
    }

    public async Task<TenantDto> Handle(UpsertTenantRequest request, CancellationToken cancellationToken)
    {
        var upsertEntity = _mapper.Map<TenantEntity>(request.Tenant);
        
        using var context = _dbContextFactory.Create(request.Tenant.Id);

        var existingTenant = context.Tenants.Find(request.Tenant.Id);

        if (existingTenant is null) context.Tenants.Add(upsertEntity);
        else context.Tenants.Update(upsertEntity);

        await context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TenantDto>(upsertEntity);
    }

    public async Task Handle(DeleteTenantRequest request, CancellationToken cancellationToken)
    {
        using var context = _dbContextFactory.Create(request.Tenant.Id);

        context.TrackedItems.RemoveRange(context.TrackedItems);
        context.UntrackedItems.RemoveRange(context.UntrackedItems);
        context.Tags.RemoveRange(context.Tags);
        context.Locations.RemoveRange(context.Locations);
        context.LocationTypes.RemoveRange(context.LocationTypes);
        context.Tenants.RemoveRange(context.Tenants);

        await context.SaveChangesAsync(cancellationToken);
    }
}